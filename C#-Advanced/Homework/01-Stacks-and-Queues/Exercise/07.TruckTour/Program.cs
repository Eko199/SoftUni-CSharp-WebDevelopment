using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.TruckTour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var pumpsQueue = new Queue<(int, int)>();

            for (int i = 0; i < n; i++)
            {
                int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
                pumpsQueue.Enqueue((input[0], input[1]));
            }
            
            for (int i = 0; i < n; i++)
            {
                int petrol = 0;

                for (int j = 0; j < n; j++)
                {
                    (int, int) current = pumpsQueue.Dequeue();
                    pumpsQueue.Enqueue(current);

                    if (petrol >= 0) petrol += current.Item1 - current.Item2;
                }

                if (petrol >= 0)
                {
                    Console.WriteLine(i);
                    break;
                }

                pumpsQueue.Enqueue(pumpsQueue.Dequeue());
            }
        }
    }
}
