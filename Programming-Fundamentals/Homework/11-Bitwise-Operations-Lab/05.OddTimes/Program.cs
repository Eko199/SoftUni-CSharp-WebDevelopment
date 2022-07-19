using System;
using System.Linq;

namespace _05.OddTimes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Console.ReadLine().Split().Select(int.Parse).ToArray().Aggregate(0, (current, number) => current ^ number));
        }
    }
}
