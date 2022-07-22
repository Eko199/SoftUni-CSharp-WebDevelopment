using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02.RageQuit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MatchCollection matches = Regex.Matches(Console.ReadLine(), @"(?<string>\D+)(?<count>\d+)");
            int uniqueSymbolsCount = string.Join(string.Empty, 
                    matches.Where(match => match.Groups["count"].Value != "0")
                        .Select(match => match.Groups["string"].Value.ToLower()))
                .Distinct()
                .Count();

            Console.WriteLine("Unique symbols used: " + uniqueSymbolsCount);

            foreach (Match match in matches)
            {
                int count = int.Parse(match.Groups["count"].Value);
                for (int i = 0; i < count; i++)
                {
                    Console.Write(match.Groups["string"].Value.ToUpper());
                }
            }
        }
    }
}
