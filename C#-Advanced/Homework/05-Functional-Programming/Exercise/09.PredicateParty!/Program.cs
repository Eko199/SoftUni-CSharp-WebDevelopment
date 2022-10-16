using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.PredicateParty_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Action<List<string>, Predicate<string>> remove = (people, criteria) => people.RemoveAll(criteria);
            Action<List<string>, Predicate<string>> doubleInList = (people, criteria) =>
            {
                for (int i = 0; i < people.Count; i++)
                {
                    if (criteria(people[i])) 
                        people.Insert(i, people[i++]);
                }
            };

            List<string> guests = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();

            string command = Console.ReadLine();
            while (command != "Party!")
            {
                string[] tokens = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                Predicate<string> criteria = str => tokens[1] switch
                {
                    "StartsWith" => str.StartsWith(tokens[2]),
                    "EndsWith" => str.EndsWith(tokens[2]),
                    "Length" => str.Length == int.Parse(tokens[2])
                };

                switch (tokens[0])
                {
                    case "Remove":
                        remove(guests, criteria);
                        break;
                    case "Double":
                        doubleInList(guests, criteria);
                        break;
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(guests.Any() 
                ? string.Join(", ", guests) + " are going to the party!" 
                : "Nobody is going to the party!");
        }
    }
}
