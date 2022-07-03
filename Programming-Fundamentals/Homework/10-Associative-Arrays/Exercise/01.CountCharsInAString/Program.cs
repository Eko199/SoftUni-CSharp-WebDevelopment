using System;
using System.Collections.Generic;

namespace _01.CountCharsInAString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();
            Dictionary<char, int> charCounts = new Dictionary<char, int>();

            foreach (char c in str)
            {
                if (charCounts.ContainsKey(c))
                    charCounts[c]++;
                else if (c != ' ')
                    charCounts[c] = 1;
            }

            foreach (var (c, count) in charCounts)
            {
                Console.WriteLine($"{c} -> {count}");
            }
        }
    }
}
