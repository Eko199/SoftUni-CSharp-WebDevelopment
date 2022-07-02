using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.OddOccurrence
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().ToLower().Split();
            Dictionary<string, int> occurrences = new Dictionary<string, int>();

            foreach (string word in words)
            {
                if (occurrences.ContainsKey(word))
                    occurrences[word]++;
                else
                    occurrences[word] = 1;
            }

            Console.WriteLine(string.Join(' ', occurrences.Where(pair => pair.Value % 2 == 1).Select(pair => pair.Key)));
        }
    }
}
