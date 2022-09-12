using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.FastFood
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int food = int.Parse(Console.ReadLine());
            var queue = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));

            Console.WriteLine(queue.Max());
            while (queue.Count > 0)
            {
                if (food >= queue.Peek())
                    food -= queue.Dequeue();
                else
                {
                    Console.WriteLine("Orders left: " + string.Join(" ", queue));
                    break;
                }
            }

            if (queue.Count == 0)
                Console.WriteLine("Orders complete");
        }
    }
}
