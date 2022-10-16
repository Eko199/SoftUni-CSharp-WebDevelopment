using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.PartyReservationFilterModule
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var filters = new Dictionary<(string, string), Predicate<string>>();
            List<string> guests = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();

            string command = Console.ReadLine();
            while (command != "Print")
            {
                string[] tokens = command.Split(';', StringSplitOptions.RemoveEmptyEntries);

                switch (tokens[0])
                {
                    case "Add filter":
                        filters.Add((tokens[1], tokens[2]), str => tokens[1] switch
                        {
                            "Starts with" => str.StartsWith(tokens[2]),
                            "Ends with" => str.EndsWith(tokens[2]),
                            "Length" => str.Length == int.Parse(tokens[2]),
                            "Contains" => str.Contains(tokens[2])
                        });

                        break;
                    case "Remove filter":
                        filters.Remove((tokens[1], tokens[2]));
                        break;
                }

                command = Console.ReadLine();
            }

            foreach (var filter in filters)
            {
                guests.RemoveAll(filter.Value);
            }

            Console.WriteLine(string.Join(' ', guests));
        }
    }
}
