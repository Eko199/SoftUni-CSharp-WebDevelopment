using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.ChangeList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine().Split().Select(int.Parse).ToList();
            string input = Console.ReadLine();

            while (!input.Equals("end"))
            {
                string[] tokens = input.Split();
                switch (tokens[0])
                {
                    case "Delete":
                        list.RemoveAll(num => num == int.Parse(tokens[1]));
                        break;
                    case "Insert":
                        list.Insert(int.Parse(tokens[2]), int.Parse(tokens[1]));
                        break;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", list));
        }
    }
}
