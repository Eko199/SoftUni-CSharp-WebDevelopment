using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _10.ForceBook
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var forceSides = new Dictionary<string, SortedSet<string>>();

            string input = Console.ReadLine();
            while (input != "Lumpawaroo")
            {
                Regex delimiter = new Regex(@" -> | \| ");
                string[] tokens = delimiter.Split(input);

                if (input.Contains(" -> "))
                {
                    (tokens[0], tokens[1]) = (tokens[1], tokens[0]); //switch for unified command
                    Console.WriteLine($"{tokens[1]} joins the {tokens[0]} side!");

                    forceSides.ToList().ForEach(side => side.Value.Remove(tokens[1]));
                }

                if (!forceSides.Select(side => side.Value.Contains(tokens[1])).Contains(true))
                {
                    if (!forceSides.ContainsKey(tokens[0]))
                        forceSides.Add(tokens[0], new SortedSet<string>());
                    forceSides[tokens[0]].Add(tokens[1]);
                }

                input = Console.ReadLine();
            }

            foreach ((string side, SortedSet<string> people) in 
                     forceSides.Where(side => side.Value.Any())
                         .OrderByDescending(side => side.Value.Count)
                         .ThenBy(side => side.Key))
            {
                Console.WriteLine($"Side: {side}, Members: {people.Count}");
                Console.WriteLine(string.Join(Environment.NewLine, people.Select(person => "! " + person)));
            }
        }
    }
}
