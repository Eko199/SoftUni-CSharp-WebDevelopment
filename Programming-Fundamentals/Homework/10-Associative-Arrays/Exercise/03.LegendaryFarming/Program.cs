using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.LegendaryFarming
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var resources = new Dictionary<string, int>();

            var legendaries = new Dictionary<string, string>();
            legendaries.Add("shards", "Shadowmourne");
            legendaries.Add("motes", "Dragonwrath");
            legendaries.Add("fragments", "Valanyr");

            bool gotLegendary = false;
            while (!gotLegendary)
            {
                string[] tokens = Console.ReadLine().ToLower().Split();

                for (int i = 0; i < tokens.Length / 2; i++)
                {
                    int amount = int.Parse(tokens[i * 2]);
                    string resource = tokens[i * 2 + 1];

                    if (resources.ContainsKey(resource))
                        resources[resource] += amount;
                    else
                        resources.Add(resource, amount);

                    if (!legendaries.ContainsKey(resource) || resources[resource] < 250) continue;

                    resources[resource] -= 250;
                    gotLegendary = true;
                    Console.WriteLine(legendaries[resource] + " obtained!");
                    break;
                }
            }
            
            resources.Where(resource => resource.Value > 0 && legendaries.ContainsKey(resource.Key))
                .ToList()
                .ForEach(resource => Console.WriteLine($"{resource.Key}: {resource.Value}"));

            resources.Remove("shards");
            resources.Remove("motes");
            resources.Remove("fragments");

            resources.Where(resource => resource.Value > 0)
                .ToList()
                .ForEach(resource => Console.WriteLine($"{resource.Key}: {resource.Value}"));
        }
    }
}
