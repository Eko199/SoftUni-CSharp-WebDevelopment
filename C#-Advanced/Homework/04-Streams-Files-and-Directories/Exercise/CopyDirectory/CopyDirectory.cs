using System.IO;

namespace CopyDirectory
{
    using System;
    public class CopyDirectory
    {
        static void Main()
        {
            string inputPath =  @$"{Console.ReadLine()}";
            string outputPath = @$"{Console.ReadLine()}";

            CopyAllFiles(inputPath, outputPath);
        }

        public static void CopyAllFiles(string inputPath, string outputPath)
        {
            if (Directory.Exists(outputPath))
                Directory.Delete(outputPath, true);

            string newDirPath = outputPath + Path.GetDirectoryName(inputPath);
            Directory.CreateDirectory(newDirPath);

            foreach (string file in Directory.GetFiles(inputPath))
            {
                File.Copy(file, newDirPath + Path.GetFileName(file));
            }
        }
    }
}
