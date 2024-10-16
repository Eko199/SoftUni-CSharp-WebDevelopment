﻿using System;
using System.Linq;

namespace _01.ActionPrint
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Action<string> print = str => Console.WriteLine(str);
            Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList().ForEach(print);
        }
    }
}
