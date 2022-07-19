using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Judge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var contests = new Dictionary<string, Dictionary<string, int>>();

            string input = Console.ReadLine();
            while (input != "no more time")
            {
                string[] tokens = input.Split(" -> ");
                string username = tokens[0];
                string contest = tokens[1];
                int points = int.Parse(tokens[2]);

                if (!contests.ContainsKey(contest))
                    contests.Add(contest, new Dictionary<string, int> { { username, points } });
                else if (!contests[contest].ContainsKey(username) || contests[contest][username] < points)
                    contests[contest][username] = points;

                input = Console.ReadLine();
            }

            var people = new Dictionary<string, int>();

            foreach ((string contest, Dictionary<string, int> contestants) in contests)
            {
                Console.WriteLine($"{contest}: {contestants.Count} participants");

                int i = 1;
                foreach (KeyValuePair<string, int> contestant in 
                         contestants.OrderByDescending(person => person.Value).ThenBy(person => person.Key))
                {
                    Console.WriteLine($"{i++}. {contestant.Key} <::> {contestant.Value}");
                    
                    if (!people.ContainsKey(contestant.Key))
                        people.Add(contestant.Key, contestant.Value);
                    else 
                        people[contestant.Key] += contestant.Value;
                }
            }

            int j = 1;
            Console.WriteLine("Individual standings:");
            foreach (var person in 
                     people.OrderByDescending(person => person.Value).ThenBy(person => person.Key))
            {
                Console.WriteLine($"{j++}. {person.Key} -> {person.Value}");
            }
        }
    }
}
