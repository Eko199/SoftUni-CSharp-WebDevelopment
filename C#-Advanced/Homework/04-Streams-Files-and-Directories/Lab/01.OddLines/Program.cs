using System;
using System.IO;

namespace OddLines
{
    public class OddLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\Files\input.txt";
            string outputFilePath = @"..\..\..\Files\output.txt";

            ExtractOddLines(inputFilePath, outputFilePath);
        }

        public static void ExtractOddLines(string inputFilePath, string outputFilePath)
        {
            using var reader = new StreamReader(inputFilePath);
            using var writer = new StreamWriter(outputFilePath);
            int count = 1;

            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                if (count++ % 2 == 1) continue;
                writer.WriteLine(line);
            }
        }
    }
}
