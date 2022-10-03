using System.IO;
using System.Linq;
using System.Text;

namespace LineNumbers
{
    using System;
    public class LineNumbers
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";
            string outputFilePath = @"..\..\..\output.txt";

            ProcessLines(inputFilePath, outputFilePath);
        }

        public static void ProcessLines(string inputFilePath, string outputFilePath)
        {
            var sb = new StringBuilder();
            string[] lines = File.ReadAllLines(inputFilePath);

            for (int i = 0; i < lines.Length; i++)
            {
                sb.AppendLine(
                    $"Line {i + 1}: {lines[i]} ({lines[i].Count(char.IsLetter)})({lines[i].Count(char.IsPunctuation)})");
            }

            File.WriteAllText(outputFilePath, sb.ToString().TrimEnd());
        }
    }
}
