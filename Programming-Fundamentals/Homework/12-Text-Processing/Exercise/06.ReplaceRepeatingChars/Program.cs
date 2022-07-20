using System;
using System.Text;

namespace _06.ReplaceRepeatingChars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < input.Length; i++)
            {
                if (i == 0 || input[i] != input[i - 1])
                    sb.Append(input[i]);
            }

            Console.WriteLine(sb);
        }
    }
}
