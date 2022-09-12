using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.BasicQueueOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] parameters = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var queue = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));

            for (int i = 0; i < parameters[1] && queue.Count > 0; i++)
                queue.Dequeue();

            Console.WriteLine(queue.Count == 0 ? "0" : queue.Contains(parameters[2]) ? "true" : queue.Min().ToString());
        }
    }
}
