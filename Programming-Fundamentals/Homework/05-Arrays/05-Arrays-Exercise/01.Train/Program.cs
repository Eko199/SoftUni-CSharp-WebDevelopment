using System;
using System.Linq;

namespace _01.Train
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] passengers = new int[n];
            for (int i = 0; i < n; i++)
            {
                passengers[i] = int.Parse(Console.ReadLine());
            }

            Console.WriteLine(string.Join(' ', passengers));
            Console.WriteLine(passengers.Sum());
        }
    }
}
