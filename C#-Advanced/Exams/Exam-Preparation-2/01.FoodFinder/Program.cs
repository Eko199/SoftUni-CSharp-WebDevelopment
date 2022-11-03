using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.FoodFinder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var words = new Dictionary<string, HashSet<char>>
            {
                { "pear", new HashSet<char>("pear") },
                { "flour", new HashSet<char>("flour") },
                { "pork", new HashSet<char>("pork") },
                { "olive", new HashSet<char>("olive") },
            };

            var vowels = new Queue<char>(Console.ReadLine());
            var consonants = new Stack<char>(Console.ReadLine());

            while (vowels.Any() && consonants.Any())
            {
                char vowel = vowels.Dequeue();
                char consonant = consonants.Pop();

                foreach (var word in words)
                {
                    word.Value.Remove(vowel);
                    word.Value.Remove(consonant);
                }

                vowels.Enqueue(vowel);
            }

            var foundWords = words.Where(word => !word.Value.Any());

            Console.WriteLine("Words found: " + foundWords.Count());
            foreach (var word in foundWords)
            {
                Console.WriteLine(word.Key);
            }
        }
    }
}
