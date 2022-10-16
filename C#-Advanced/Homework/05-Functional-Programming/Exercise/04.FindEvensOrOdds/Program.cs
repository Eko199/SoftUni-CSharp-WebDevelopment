using System;
using System.Linq;

namespace _04.FindEvensOrOdds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Predicate<int> isOdd = x => x % 2 != 0;
            Predicate<int> isEven = x => x % 2 == 0;

            int[] bounds = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Console.WriteLine(string.Join(' ', 
                Enumerable.Range(bounds[0], bounds[1] - bounds[0] + 1)
                .ToList()
                .FindAll(Console.ReadLine() == "even" ? isEven : isOdd)));
        }
    }
}
