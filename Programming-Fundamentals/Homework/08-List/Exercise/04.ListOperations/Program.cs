using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _04.ListOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine().Split().Select(int.Parse).ToList();
            string input = Console.ReadLine();

            while (!input.Equals("End"))
            {
                string[] tokens = input.Split();

                switch (tokens[0])
                {
                    case "Add":
                        list.Add(int.Parse(tokens[1]));
                        break;
                    case "Insert":
                        int index1 = int.Parse(tokens[2]);

                        if (IsValidIndex(index1, list))
                            list.Insert(index1, int.Parse(tokens[1]));
                        else
                            Console.WriteLine("Invalid index");

                        break;
                    case "Remove":
                        int index2 = int.Parse(tokens[1]);

                        if (IsValidIndex(index2, list))
                            list.RemoveAt(index2);
                        else
                            Console.WriteLine("Invalid index");

                        break;
                    case "Shift":
                        int count = int.Parse(tokens[2]) % list.Count;

                        if (tokens[1] == "left")
                        {
                            for (int i = 0; i < count; i++)
                            {
                                int firstElement = list[0];
                                list.RemoveAt(0);
                                list.Add(firstElement);
                            }
                        }
                        else
                        {
                            for (int i = 0; i < count; i++)
                            {
                                int lastElement = list[^1];
                                list.RemoveAt(list.Count - 1);
                                list.Insert(0, lastElement);
                            }
                        }

                        break;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", list));
        }

        private static bool IsValidIndex(int index, ICollection list) => index >= 0 && index < list.Count;
    }
}
