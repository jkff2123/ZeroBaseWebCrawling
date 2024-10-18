using Microsoft.Win32;
using System.IO.Compression;

namespace ZeroBaseWebCrawling.Chapter6.Part1
{
    public class EdgeVersionController
    {
        private static string GetVersion()
        {
            var path = "HKEY_CURRENT_USER\\Software\\Microsoft\\Edge\\BLBeacon";
            var obj = Registry.GetValue(path, "version", null);
            return obj == null ? string.Empty : obj.ToString();
        }

        private static bool CheckVersion(string version)
        {
            Directory.CreateDirectory(".\\driver");
            var currentFile = Directory.GetFiles(".\\driver\\").Where(x => x.Contains("msedgedriver-")).FirstOrDefault();
            return currentFile != null ? currentFile.Contains(version) : false;
        }

        private static void DownloadDriver(string version)
        {
            var path = $"https://msedgedriver.azureedge.net/{version}/edgedriver_win64.zip";
            var client = new HttpClient();
            var response = client.GetAsync(path).Result;
            var contentStream = response.Content.ReadAsStreamAsync().Result;
            var fileINfo = new FileInfo(".\\driver\\edgedriver.zip");
            using (var fileStream = fileINfo.OpenWrite())
            {
                contentStream.CopyToAsync(fileStream).Wait();
            }
            ZipFile.ExtractToDirectory(".\\driver\\edgedriver.zip", ".\\driver\\");
            foreach (var file in Directory.GetFiles(".\\driver\\"))
            {
                if (file.Contains("msedgedriver"))
                {
                    continue;
                }
                File.Delete(file);
            }
            foreach (var dir in Directory.GetDirectories(".\\driver\\"))
            {
                Directory.Delete(dir, true);
            }
            if (File.Exists(".\\driver\\msedgedriver.exe"))
            {
                var oldFile = ".\\driver\\msedgedriver.exe";
                var newFile = $".\\driver\\msedgedriver-{version}.exe";
                File.Move(oldFile, newFile);
            }
        }

        public static void Update()
        {
            var version = GetVersion();
            if (version == string.Empty)
            {
                throw new Exception("Edge 버전 정보가 없습니다.");
            }
            if (CheckVersion(version))
            {
                return;
            }
            DownloadDriver(version);
        }
    }
}
