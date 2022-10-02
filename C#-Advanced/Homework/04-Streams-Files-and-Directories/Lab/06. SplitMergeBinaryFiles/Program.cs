using System;
using System.IO;

namespace SplitMergeBinaryFile
{
    public class SplitMergeBinaryFile
    {
        static void Main()
        {
            string sourceFilePath = @"..\..\..\Files\example.png";
            string joinedFilePath = @"..\..\..\Files\example-joined.png";
            string partOnePath = @"..\..\..\Files\part-1.bin";
            string partTwoPath = @"..\..\..\Files\part-2.bin";

            SplitBinaryFile(sourceFilePath, partOnePath, partTwoPath);
            MergeBinaryFiles(partOnePath, partTwoPath, joinedFilePath);
        }

        public static void SplitBinaryFile(string sourceFilePath, string partOneFilePath, string partTwoFilePath)
        {
            using var source = new FileStream(sourceFilePath, FileMode.Open);

            byte[] buffer = new byte[source.Length / 2 + source.Length % 2];


            using (var part1 = new FileStream(partOneFilePath, FileMode.Create))
            {
                source.Read(buffer);
                part1.Write(buffer);
            }

            using (var part2 = new FileStream(partTwoFilePath, FileMode.Create))
            {
                source.Read(buffer);
                part2.Write(buffer);
            }
        }

        public static void MergeBinaryFiles(string partOneFilePath, string partTwoFilePath, string joinedFilePath)
        {
            using var joined = new FileStream(joinedFilePath, FileMode.Create);

            using (var part1 = new FileStream(partOneFilePath, FileMode.Open))
            {
                byte[] buffer = new byte[part1.Length];

                part1.Read(buffer);
                joined.Write(buffer);
            }

            using (var part2 = new FileStream(partOneFilePath, FileMode.Open))
            {
                byte[] buffer = new byte[part2.Length];

                part2.Read(buffer);
                joined.Write(buffer);
            }
        }
    }
}
