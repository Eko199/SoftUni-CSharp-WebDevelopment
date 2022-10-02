using System;
using System.IO;
using System.Linq;

namespace FolderSize
{
    public class FolderSize
    {
        static void Main()
        {
            string folderPath = @"..\..\..\Files\TestFolder";
            string outputPath = @"..\..\..\Files\output.txt";

            GetFolderSize(folderPath, outputPath);
        }

        public static void GetFolderSize(string folderPath, string outputFilePath)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(folderPath);
            using var writer = new StreamWriter(outputFilePath);

            writer.Write(dirInfo.GetFiles("*", SearchOption.AllDirectories)
                .Sum(file => file.Length) / 1024.0 + " KB");
        }
    }
}

