using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _03.PostOffice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] parts = Console.ReadLine().Split('|');
            Dictionary<char, int> capitalsAndLengths = Regex.Match(parts[0], @"([#$%*&])(?<letters>[A-Z]+)\1")
                .Groups["letters"]
                .Value
                .ToDictionary(c => c, _ => 0);
            MatchCollection matches = Regex.Matches(parts[1], @"(\d\d):(\d\d)");

            foreach (Match match in matches)
            {
                char letter = (char)int.Parse(match.Groups[1].Value);

                if (capitalsAndLengths.ContainsKey(letter))
                    capitalsAndLengths[letter] = int.Parse(match.Groups[2].Value) + 1;
            }

            string[] words = parts[2].Split();
            foreach (KeyValuePair<char, int> kvp in capitalsAndLengths)
            {
                Console.WriteLine(words.First(word => word.StartsWith(kvp.Key) && word.Length == kvp.Value));
            }
        }
    }
}
