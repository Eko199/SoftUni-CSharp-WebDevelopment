using System;
using System.Collections.Generic;

namespace _07.HotPotato
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var peopleQueue = new Queue<string>(Console.ReadLine().Split());
            int n = int.Parse(Console.ReadLine());

            while (peopleQueue.Count > 1)
            {
                for (int i = 1; i < n; i++)
                    peopleQueue.Enqueue(peopleQueue.Dequeue());
                Console.WriteLine("Removed " + peopleQueue.Dequeue());
            }

            Console.WriteLine("Last is " + peopleQueue.Dequeue());
        }
    }
}
