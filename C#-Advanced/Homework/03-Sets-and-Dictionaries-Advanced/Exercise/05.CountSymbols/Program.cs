using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.CountSymbols
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var occurrences = new SortedDictionary<char, int>();
            string input = Console.ReadLine();

            foreach (char c in input)
            {
                if (!occurrences.ContainsKey(c))
                    occurrences[c] = 0;

                occurrences[c]++;
            }

            foreach (var (c, count) in occurrences)
            {
                Console.WriteLine($"{c}: {count} time/s");
            }
        }
    }
}
