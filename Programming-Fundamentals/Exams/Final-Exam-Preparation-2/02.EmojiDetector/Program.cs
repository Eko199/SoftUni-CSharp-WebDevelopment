using System;
using System.Linq;
using System.Numerics;
using System.Text.RegularExpressions;

namespace _02.EmojiDetector
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            long coolThreshold = input.Where(char.IsDigit).Aggregate(1L, (currMult, c) => currMult * int.Parse(c.ToString()));
            Console.WriteLine("Cool threshold: " + coolThreshold);

            MatchCollection emojis = Regex.Matches(input, @"(::|\*\*)[A-Z][a-z]{2,}\1");
            Console.WriteLine(emojis.Count + " emojis found in the text. The cool ones are:");
            
            emojis.Where(emoji => emoji.Value
                .Where(char.IsLetter)
                .Sum(c => c) > coolThreshold)
                .ToList()
                .ForEach(Console.WriteLine);
        }
    }
}
