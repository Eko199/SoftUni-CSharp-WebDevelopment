using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _04.StarEnigma
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var attackedPlanets = new List<string>();
            var destroyedPlanets = new List<string>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                int key = input.Count(c => new[] { 's', 't', 'a', 'r' }.Contains(char.ToLower(c)));
                string message = new string(input.Select(c => (char)(c - key)).ToArray());

                Regex regex = new Regex(
                @"@(?<planet>[A-Z][a-z]+)[^@\-!:>]*:(?<population>\d+)[^@\-!:>]*!(?<attackType>[AD])![^@\-!:>]*->(?<soldiers>\d+)");
                Match match = regex.Match(message);

                if (!match.Success) continue;

                if (match.Groups["attackType"].Value == "A")
                    attackedPlanets.Add(match.Groups["planet"].Value);
                else
                    destroyedPlanets.Add(match.Groups["planet"].Value);
            }

            Console.WriteLine($"Attacked planets: {attackedPlanets.Count}");
            attackedPlanets.OrderBy(planet => planet).ToList().ForEach(planet => Console.WriteLine("-> " + planet));
            Console.WriteLine($"Destroyed planets: {destroyedPlanets.Count}");
            destroyedPlanets.OrderBy(planet => planet).ToList().ForEach(planet => Console.WriteLine("-> " + planet));
        }
    }
}
