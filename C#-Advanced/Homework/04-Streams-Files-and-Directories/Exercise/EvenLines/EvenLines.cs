using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace EvenLines
{
    using System;
    public class EvenLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";

            Console.WriteLine(ProcessLines(inputFilePath));
        }

        public static string ProcessLines(string inputFilePath)
        {
            var sb = new StringBuilder();
            using var reader = new StreamReader(inputFilePath);

            for (int i = 0; !reader.EndOfStream; i++)
            {
                string line = reader.ReadLine();
                if (i % 2 != 0) continue;

                sb.AppendLine(string.Join(' ', 
                    Regex.Replace(line, @"[-,.!?]", "@")
                    .Split()
                    .Reverse()));
            }

            return sb.ToString().TrimEnd();
        }
    }
}
