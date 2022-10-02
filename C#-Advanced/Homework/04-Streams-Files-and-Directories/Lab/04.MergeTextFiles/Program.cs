using System;
using System.IO;

namespace MergeFiles
{
    public class MergeFiles
    {
        static void Main()
        {
            var firstInputFilePath = @"..\..\..\Files\input1.txt";
            var secondInputFilePath = @"..\..\..\Files\input2.txt";
            var outputFilePath = @"..\..\..\Files\output.txt";

            MergeTextFiles(firstInputFilePath, secondInputFilePath, outputFilePath);
        }

        public static void MergeTextFiles(string firstInputFilePath, string secondInputFilePath, string outputFilePath)
        {
            using var reader1 = new StreamReader(firstInputFilePath);
            using var reader2 = new StreamReader(secondInputFilePath);
            using var writer = new StreamWriter(outputFilePath);

            while (!reader1.EndOfStream && !reader2.EndOfStream)
            {
                writer.WriteLine(reader1.ReadLine());
                writer.WriteLine(reader2.ReadLine());
            }

            if (!reader1.EndOfStream)
                writer.Write(reader1.ReadToEnd());
            else if (!reader2.EndOfStream)
                writer.Write(reader2.ReadToEnd());
        }
    }
}

