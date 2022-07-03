using System;
using System.Collections.Generic;

namespace _02.AMinerTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var resources = new Dictionary<string, int>();
            
            string input = Console.ReadLine();
            while (input != "stop")
            {
                int amount = int.Parse(Console.ReadLine());

                if (resources.ContainsKey(input))
                    resources[input] += amount;
                else
                    resources[input] = amount;

                input = Console.ReadLine();
            }

            foreach (var (resource, amount) in resources)
            {
                Console.WriteLine($"{resource} -> {amount}");
            }
        }
    }
}
