using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.ListManipulationBasics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine().Split().Select(int.Parse).ToList();
            string input = Console.ReadLine();

            while (!input.Equals("end"))
            {
                string[] commands = input.Split();

                switch (commands[0])
                {
                    case "Add":
                        list.Add(int.Parse(commands[1]));
                        break;
                    case "Remove":
                        list.Remove(int.Parse(commands[1]));
                        break;
                    case "RemoveAt":
                        list.RemoveAt(int.Parse(commands[1]));
                        break;
                    case "Insert":
                        list.Insert(int.Parse(commands[2]), int.Parse(commands[1]));
                        break;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", list));
        }
    }
}
