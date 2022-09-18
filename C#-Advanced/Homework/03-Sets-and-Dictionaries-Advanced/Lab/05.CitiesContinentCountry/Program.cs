using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.CitiesContinentCountry
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var cities = new Dictionary<string, Dictionary<string, List<string>>>();
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string[] location = Console.ReadLine().Split();

                if (!cities.ContainsKey(location[0]))
                    cities.Add(location[0], new Dictionary<string, List<string>>());
                if (!cities[location[0]].ContainsKey(location[1]))
                    cities[location[0]].Add(location[1], new List<string>());

                cities[location[0]][location[1]].Add(location[2]);
            }

            foreach ((string continent, Dictionary<string, List<string>> countryCities) in cities)
            {
                Console.WriteLine(continent + ":");
                Console.WriteLine(string.Join(Environment.NewLine, 
                    countryCities.Select(pair => $"\t{pair.Key} -> {string.Join(", ", pair.Value)}")));
            }
        }
    }
}
