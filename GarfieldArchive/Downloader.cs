using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GarfieldArchive
{
    internal class Downloader
    {
        private readonly List<Task> _tasks = new List<Task>();
        private readonly Dictionary<int, DataRow> _yearRows = new Dictionary<int, DataRow>();
        public readonly DataTable DataTable = new DataTable();

        public Downloader()
        {
            DataTable.Columns.Add("Year", typeof (int));
            DataTable.Columns.Add("Published", typeof (int));
            DataTable.Columns.Add("Downloaded", typeof (int));
        }

        public async Task DownloadAll(string outputDir)
        {
            var strip = ComicStrip.FirstStrip;
            do
            {
                AddYearRowIfDoesNotExist(strip);

                var currentStrip = strip; // Needed for thread safety

                var task = new Task((() =>
                {
                    ProcessStrip(currentStrip, outputDir);
                    lock (_yearRows)
                    {
                        var row = _yearRows[currentStrip.Year];
                        row[2] = row.Field<int>(2) + 1;
                    }
                }));

                task.Start();
                _tasks.Add(task);

                // Execute no more than 5 tasks at once
                if (_tasks.Count >= 5)
                {
                    await WaitForFreeTaskSlot();
                }
            } while ((strip = strip.NextStrip()) != null);
        }

        private void AddYearRowIfDoesNotExist(ComicStrip strip)
        {
            lock (_yearRows)
            {
                if (!_yearRows.ContainsKey(strip.Year))
                {
                    var endDate = new DateTime(strip.Year + 1, 1, 1);
                    if (endDate > DateTime.Today)
                    {
                        endDate = DateTime.Today;
                    }

                    var timeSpan = endDate - strip.Date;
                    _yearRows.Add(strip.Year, DataTable.Rows.Add(strip.Year, timeSpan.TotalDays, 0));
                }
            }
        }

        private static void ProcessStrip(ComicStrip strip, string folder)
        {
            // Check if local year directory exists and create if it doesn't
            var localDirectory = Path.Combine(folder, strip.Year.ToString());
            if (!Directory.Exists(localDirectory))
            {
                Directory.CreateDirectory(localDirectory);
            }

            // Initialize file pathes for GIF and PNG format
            var gifPath = Path.Combine(localDirectory, strip.GetFilename("gif"));
            var pngPath = Path.Combine(localDirectory, strip.GetFilename("png"));

            // Check if PNG already exists
            if (File.Exists(pngPath))
            {
                var length = new FileInfo(pngPath).Length;
                if (length > 0)
                {
                    File.Delete(gifPath);
                    return;
                }
            }

            // Download image on computer
            if (!File.Exists(gifPath))
            {
                strip.Download(gifPath);
            }

            // Convert to PNG
            ComicStrip.ConvertToPng(gifPath);

            // When successfully converted to PNG, remove GIF image
            if (File.Exists(pngPath))
            {
                File.Delete(gifPath);
            }
        }

        private async Task WaitForFreeTaskSlot()
        {
            await Task.WhenAny(_tasks);
            foreach (var task in _tasks.ToArray().Where(task => task.IsCompleted))
            {
                _tasks.Remove(task);
            }
        }
    }
}