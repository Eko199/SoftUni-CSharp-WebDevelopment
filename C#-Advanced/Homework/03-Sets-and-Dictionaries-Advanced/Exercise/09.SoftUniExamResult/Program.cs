using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.SoftUniExamResult
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var people = new Dictionary<string, int>();
            var submissions = new Dictionary<string, int>();

            string input = Console.ReadLine();
            while (input != "exam finished")
            {
                string[] tokens = input.Split('-');

                if (tokens[1] == "banned")
                    people.Remove(tokens[0]);
                else
                {
                    int points = int.Parse(tokens[2]);

                    if (!people.ContainsKey(tokens[0]))
                        people.Add(tokens[0], points);
                    else if (people[tokens[0]] < points)
                        people[tokens[0]] = points;

                    if (!submissions.ContainsKey(tokens[1]))
                        submissions.Add(tokens[1], 0);
                    submissions[tokens[1]]++;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine("Results:");
            foreach (var person in 
                     people.OrderByDescending(person => person.Value)
                         .ThenBy(person => person.Key))
            {
                Console.WriteLine($"{person.Key} | {person.Value}");
            }

            Console.WriteLine("Submissions:");
            foreach (var submission in 
                     submissions.OrderByDescending(submission => submission.Value)
                         .ThenBy(submission => submission.Key))
            {
                Console.WriteLine($"{submission.Key} - {submission.Value}");
            }
        }
    }
}
