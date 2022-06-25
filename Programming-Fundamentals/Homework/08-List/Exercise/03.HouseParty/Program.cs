using System;
using System.Collections.Generic;

namespace _03.HouseParty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> list = new List<string>();
            int commandsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < commandsCount; i++)
            {
                string[] tokens = Console.ReadLine().Split();
                string name = tokens[0];

                if (tokens[2] == "not")
                {
                    if (!list.Remove(name))
                        Console.WriteLine($"{name} is not in the list!");
                    continue;
                }

                if (list.Contains(name))
                    Console.WriteLine($"{name} is already in the list!");
                else
                    list.Add(name);
            }

            list.ForEach(Console.WriteLine);
        }
    }
}
