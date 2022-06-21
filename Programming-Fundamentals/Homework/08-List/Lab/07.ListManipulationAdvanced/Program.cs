using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.ListManipulationAdvanced
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine().Split().Select(int.Parse).ToList();
            string input = Console.ReadLine();
            bool hasChanged = false;

            while (!input.Equals("end"))
            {
                string[] commands = input.Split();

                switch (commands[0])
                {
                    case "Add":
                        list.Add(int.Parse(commands[1]));
                        hasChanged = true;
                        break;
                    case "Remove":
                        list.Remove(int.Parse(commands[1]));
                        hasChanged = true;
                        break;
                    case "RemoveAt":
                        list.RemoveAt(int.Parse(commands[1]));
                        hasChanged = true;
                        break;
                    case "Insert":
                        list.Insert(int.Parse(commands[2]), int.Parse(commands[1]));
                        hasChanged = true;
                        break;
                    case "Contains":
                        Console.WriteLine(list.Contains(int.Parse(commands[1])) ? "Yes" : "No such number");
                        break;
                    case "PrintEven":
                        Console.WriteLine(string.Join(" ", list.Where(n => n % 2 == 0)));
                        break;
                    case "PrintOdd":
                        Console.WriteLine(string.Join(" ", list.Where(n => n % 2 == 1)));
                        break;
                    case "GetSum":
                        Console.WriteLine(list.Sum());
                        break;
                    case "Filter":
                        int comparisonNumber = int.Parse(commands[2]);

                        switch (commands[1])
                        {
                            case ">":
                                Console.WriteLine(string.Join(" ", list.Where(n => n > comparisonNumber)));
                                break;
                            case "<":
                                Console.WriteLine(string.Join(" ", list.Where(n => n < comparisonNumber)));
                                break;
                            case ">=":
                                Console.WriteLine(string.Join(" ", list.Where(n => n >= comparisonNumber)));
                                break;
                            case "<=":
                                Console.WriteLine(string.Join(" ", list.Where(n => n <= comparisonNumber)));
                                break;
                        }

                        break;
                }

                input = Console.ReadLine();
            }

            if (hasChanged)
                Console.WriteLine(string.Join(" ", list));
        }
    }
}
