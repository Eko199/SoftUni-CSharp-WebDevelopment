using System;
using System.Collections.Generic;

namespace _03.WordSynonyms
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var synonyms = new Dictionary<string, List<string>>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string word = Console.ReadLine(), synonym = Console.ReadLine();
                if (synonyms.ContainsKey(word))
                    synonyms[word].Add(synonym);
                else
                    synonyms.Add(word, new List<string> { synonym });
            }

            foreach (var (word, synonymsList) in synonyms)
            {
                Console.WriteLine($"{word} - {string.Join(", ", synonymsList)}");
            }
        }
    }
}
