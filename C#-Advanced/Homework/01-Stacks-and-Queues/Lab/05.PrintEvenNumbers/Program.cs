using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.PrintEvenNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var queue = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            bool first = true;

            while (queue.Count > 0)
            {
                int current = queue.Dequeue();
                if (current % 2 != 0) continue;

                if (!first) Console.Write(", ");
                Console.Write(current);
                first = false;
            }
        }
    }
}
