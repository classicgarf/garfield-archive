using System;
using System.Diagnostics;
using System.IO;
using System.Net;

namespace GarfieldArchive
{
    internal class ComicStrip
    {
        public readonly string Basename;
        public readonly DateTime Date;
        public readonly int Year;
        public readonly int Month;
        public readonly string PadMonth;
        public readonly string ISOdate;

        public ComicStrip(DateTime date)
        {
            Date = date;
            Year = int.Parse($"{Date:yyyy}");
            Month = int.Parse($"{Date:MM}");
            PadMonth = $"{Date:MM}";
            Basename = $"ga{Date:yyMMdd}";
            ISOdate = $"{Date:yyyy-MM-dd}";
        }

        public static ComicStrip FirstStrip => new ComicStrip(MainForm.startStrip);

        public string RemoteUrl => "http://professorgarfield.org/ipi1200/" + Year + "/" +
                                   GetFilename("gif");

        public string GetFilename(string extension)
        {
            return Basename + "." + extension;
        }

        public string GetISOFilename(string extension)
        {
            return ISOdate + "." + extension;
        }

        /// <summary>
        ///     Downloads strip on disk.
        /// </summary>
        /// <param name="localPath">Path where the downloaded image will be saved.</param>
        public void Download(string localPath)
        {
            var webClient = new WebClient();
            webClient.DownloadFile(RemoteUrl, localPath);
        }

        /// <summary>
        ///     Returns next strip or NULL when reached most recent one.
        /// </summary>
        /// <returns></returns>
        public ComicStrip NextStrip()
        {
            var nextDate = Date.Add(TimeSpan.FromDays(1));
            return nextDate.Date > DateTime.Today ? null : new ComicStrip(nextDate);
        }

        /// <summary>
        ///     Synchronously converts image to optimized PNG.
        /// </summary>
        /// <param name="path">Path to input image file.</param>
        public static void ConvertToPng(string path)
        {
            var startInfo = new ProcessStartInfo
            {
                FileName = Path.Combine(Environment.CurrentDirectory, "optipng.exe"),
                Arguments = path,
                CreateNoWindow = true,
                UseShellExecute = false
            };

            Process.Start(startInfo)?.WaitForExit();
        }
    }
}