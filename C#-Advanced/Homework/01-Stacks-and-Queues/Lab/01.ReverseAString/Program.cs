﻿using System;
using System.Collections.Generic;

namespace _01.ReverseAString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var stack = new Stack<char>();

            foreach (char c in input)
            {
                stack.Push(c);
            }

            while (stack.Count > 0)
                Console.Write(stack.Pop());
        }
    }
}
