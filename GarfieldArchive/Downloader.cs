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
        public static string localDirectory { set; get; }
        public static string oppositeDirectory { set; get; }

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
            var yearDirectory = Path.Combine(folder, strip.Year.ToString());
            var monthDirectory = Path.Combine(folder, strip.Year.ToString(), strip.PadMonth);
            // Check if local date directory exists and create if it doesn't
            if (MainForm.monthFoldersCheck == true)
            {
                localDirectory = monthDirectory;
                oppositeDirectory = yearDirectory;
            }
            else
            {
                localDirectory = yearDirectory;
                oppositeDirectory = monthDirectory;
            }
                
            if (!Directory.Exists(localDirectory))
            {
                Directory.CreateDirectory(localDirectory);
            }

            // Initialize file path
            var gifGAPath = Path.Combine(localDirectory, strip.GetFilename("gif"));
            var gifISOPath = Path.Combine(localDirectory, strip.GetISOFilename("gif"));
            var pngGAPath = Path.Combine(localDirectory, strip.GetFilename("png"));
            var pngISOPath = Path.Combine(localDirectory, strip.GetISOFilename("png"));

            // Check if other sorting exists
            var opgifGAPath = Path.Combine(oppositeDirectory, strip.GetFilename("gif"));
            var opgifISOPath = Path.Combine(oppositeDirectory, strip.GetISOFilename("gif"));
            var oppngGAPath = Path.Combine(oppositeDirectory, strip.GetFilename("png"));
            var oppngISOPath = Path.Combine(oppositeDirectory, strip.GetISOFilename("png"));
            if (File.Exists(opgifGAPath))
            {
                File.Move(opgifGAPath, gifGAPath);
            }
            if (File.Exists(oppngGAPath))
            {
                File.Move(oppngGAPath, pngGAPath);
            }
            if (File.Exists(opgifISOPath))
            {
                File.Move(opgifISOPath, gifISOPath);
            }
            if (File.Exists(oppngISOPath))
            {
                File.Move(oppngISOPath, pngISOPath);
            }

            if (MainForm.chooseISOCheck == true)
            {
                // Check if gaYYMMDD file exists
                if (File.Exists(gifGAPath))
                {
                    if (File.Exists(gifISOPath))
                    {
                        File.Delete(gifGAPath);
                    }
                    else
                    {
                        File.Move(gifGAPath, gifISOPath);
                    }
                    return;
                }
                if (File.Exists(pngGAPath))
                {
                    if (File.Exists(pngISOPath))
                    {
                        File.Delete(pngGAPath);
                    }
                    else
                    {
                        File.Move(pngGAPath, pngISOPath);
                    }
                    return;
                }
            }
            else
            {
                // Check if YYYY-MM-DD file exists
                if (File.Exists(gifISOPath))
                {
                    if (File.Exists(gifGAPath))
                    {
                        File.Delete(gifISOPath);
                    }
                    else
                    {
                        File.Move(gifISOPath, gifGAPath);
                    }
                    return;
                }
                if (File.Exists(pngISOPath))
                {
                    if (File.Exists(gifGAPath))
                    {
                        File.Delete(gifISOPath);
                    }
                    else
                    {
                        File.Move(gifISOPath, gifGAPath);
                    }
                    return;
                }
            }

            if (MainForm.convert2PNG == true)
            {
                // Check if PNG already exists
                if (File.Exists(pngGAPath) || File.Exists(pngISOPath))
                {
                    var length = new FileInfo(pngGAPath).Length;
                    if (length > 0)
                    {
                        File.Delete(gifGAPath);
                        File.Delete(gifISOPath);
                        return;
                    }
                }

                // Download image on computer
                if (!File.Exists(gifGAPath))
                {
                    strip.Download(gifGAPath);

                }

                // Convert to PNG
                ComicStrip.ConvertToPng(gifGAPath);

                // When successfully converted to PNG, remove GIF image
                if (File.Exists(pngGAPath))
                {
                    File.Delete(gifGAPath);
                }

                if (MainForm.chooseISOCheck == true) { File.Move(pngGAPath, pngISOPath); File.Delete(pngGAPath); }
            } 
            else
            {
                // Download image on computer
                if (!File.Exists(gifGAPath))
                {
                    strip.Download(gifGAPath);
                    if (MainForm.chooseISOCheck == true) { 
                        if (File.Exists(gifISOPath)) {
                            File.Delete(gifGAPath);
                        }
                        else
                        {
                            File.Move(gifGAPath, gifISOPath);
                        }
                        
                    }
                }
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