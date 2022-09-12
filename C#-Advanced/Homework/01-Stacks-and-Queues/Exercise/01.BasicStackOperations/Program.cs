using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.BasicStackOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] parameters = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var stack = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));

            for (int i = 0; i < parameters[1] && stack.Count > 0; i++)
                stack.Pop();

            Console.WriteLine(stack.Count == 0 ? "0" : stack.Contains(parameters[2]) ? "true" : stack.Min().ToString());
        }
    }
}
