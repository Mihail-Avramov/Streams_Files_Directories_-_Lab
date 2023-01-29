namespace FolderSize
{
    using System.IO;
    public class FolderSize
    {
        static void Main(string[] args)
        {
            string folderPath = @"..\..\..\Files\TestFolder";
            string outputPath = @"..\..\..\Files\output.txt";

            GetFolderSize(folderPath, outputPath);
        }

        public static void GetFolderSize(string folderPath, string outputFilePath)
        {
            long fileSize = GetFolderSize(folderPath);
            File.WriteAllText(outputFilePath, $"{(double)fileSize / 1024} KB");
        }

        private static long GetFolderSize(string folderPath)
        {
            string[] filePaths = Directory.GetFiles(folderPath);

            long size = 0;

            foreach (string file in filePaths)
            {
                FileInfo fileInfo = new FileInfo(file);
                size += fileInfo.Length;
            }

            foreach (var directory in Directory.GetDirectories(folderPath))
            {
                size += GetFolderSize(directory);
            }

            return size;
        }
    }
}
