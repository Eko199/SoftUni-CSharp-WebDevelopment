using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.StackSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var stack = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));

            string command = Console.ReadLine().ToLower();
            while (command != "end")
            {
                string[] tokens = command.Split();

                switch (tokens[0])
                {
                    case "add":
                        stack.Push(int.Parse(tokens[1]));
                        stack.Push(int.Parse(tokens[2]));
                        break;
                    case "remove":
                        int amount = int.Parse(tokens[1]);
                        for (int i = 0; i < amount && amount <= stack.Count; i++)
                            stack.Pop();
                        break;
                }

                command = Console.ReadLine().ToLower();
            }

            Console.WriteLine("Sum: " + stack.Sum());
        }
    }
}
