using System;
using System.IO;

namespace LineNumbers
{
    public class LineNumbers
    {
        static void Main()
        {
            string inputPath = @"..\..\..\Files\input.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            RewriteFileWithLineNumbers(inputPath, outputPath);
        }

        public static void RewriteFileWithLineNumbers(string inputFilePath, string outputFilePath)
        {
            using var reader = new StreamReader(inputFilePath);
            using var writer = new StreamWriter(outputFilePath);
            int count = 1;

            while (!reader.EndOfStream)
            {
                writer.WriteLine($"{count++}. {reader.ReadLine()}");
            }
        }
    }
}

