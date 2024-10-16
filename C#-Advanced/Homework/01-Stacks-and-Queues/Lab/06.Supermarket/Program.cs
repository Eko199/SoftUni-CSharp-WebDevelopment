﻿using System;
using System.Collections.Generic;

namespace _06.Supermarket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var queue = new Queue<string>();

            string input = Console.ReadLine();
            while (input != "End")
            {
                if (input == "Paid")
                {
                    while (queue.Count > 0)
                    {
                        Console.WriteLine(queue.Dequeue());
                    }
                }
                else
                {
                    queue.Enqueue(input);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(queue.Count + " people remaining.");
        }
    }
}
