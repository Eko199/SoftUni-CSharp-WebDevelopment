using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Race
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> people = Console.ReadLine().Split(", ").ToDictionary(x => x, x => 0);

            string input = Console.ReadLine();
            while (input != "end of race")
            {
                string name = new string(input.Where(char.IsLetter).ToArray());

                if (people.ContainsKey(name) && input.Any(char.IsDigit))
                    people[name] += input.Where(char.IsDigit).Select(c => int.Parse(c.ToString())).Sum();

                input = Console.ReadLine();
            }

            List<string> top3 = people
                .OrderByDescending(person => person.Value)
                .Take(3)
                .Select(person => person.Key)
                .ToList();

            Console.WriteLine($"1st place: {top3[0]}\n"+
                $"2nd place: {top3[1]}\n"+
                $"3rd place: {top3[2]}");
        }
    }
}
