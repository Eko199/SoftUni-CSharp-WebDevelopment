using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Train
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> wagons = Console.ReadLine().Split().Select(int.Parse).ToList();
            int wagonCapacity = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();

            while (!input.Equals("end"))
            {
                string[] tokens = input.Split();
                if (tokens[0] == "Add")
                {
                    wagons.Add(int.Parse(tokens[1]));
                }
                else
                {
                    int passengers = int.Parse(tokens[0]);

                    try
                    {
                        wagons[wagons.IndexOf(wagons.Find(wagon => wagon + passengers <= wagonCapacity))] += passengers;
                    }
                    catch (Exception ignored)
                    {}
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", wagons));
        }
    }
}
