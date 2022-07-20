using System;

namespace _02.AsciiSumator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int c1 = char.Parse(Console.ReadLine());
            int c2 = char.Parse(Console.ReadLine());
            string input = Console.ReadLine();

            int min = Math.Min(c1, c2), max = Math.Max(c1, c2);
            int sum = 0;

            foreach (char c in input)
            {
                if (c > min && c < max) sum += c;
            }

            Console.WriteLine(sum);
        }
    }
}
