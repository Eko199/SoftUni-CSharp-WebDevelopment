using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Ranking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var passwords = new Dictionary<string, string>();

            string input = Console.ReadLine();
            while (input != "end of contests")
            {
                string[] contestPassword = input.Split(':');
                passwords[contestPassword[0]] = contestPassword[1];
                input = Console.ReadLine();
            }

            var people = new Dictionary<string, Dictionary<string, int>>();

            input = Console.ReadLine();
            while (input != "end of submissions")
            {
                string[] tokens = input.Split("=>");

                if (passwords.ContainsKey(tokens[0]) && passwords[tokens[0]] == tokens[1])
                {
                    if (!people.ContainsKey(tokens[2]))
                        people.Add(tokens[2], new Dictionary<string, int> { { tokens[0], int.Parse(tokens[3]) } });
                    else if (!people[tokens[2]].ContainsKey(tokens[0]) || people[tokens[2]][tokens[0]] < int.Parse(tokens[3]))
                        people[tokens[2]][tokens[0]] = int.Parse(tokens[3]);
                }

                input = Console.ReadLine();
            }

            KeyValuePair<string, int> bestPerson = people
                .ToDictionary(person => person.Key, person => person.Value.Values.Sum())
                .OrderByDescending(kvp => kvp.Value).ToArray()[0];

            Console.WriteLine($"Best candidate is {bestPerson.Key} with total {bestPerson.Value} points.");

            Console.WriteLine("Ranking: ");
            foreach (var (name, contests) in people.OrderBy(person => person.Key))
            {
                Console.WriteLine(name);
                foreach (KeyValuePair<string, int> contest in contests.OrderByDescending(contest => contest.Value))
                {
                    Console.WriteLine($"#  {contest.Key} -> {contest.Value}");
                }
            }
        }
    }
}
