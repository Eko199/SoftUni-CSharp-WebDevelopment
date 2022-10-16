using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.ListOfPredicates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<int> divisors = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            List<Predicate<int>> isDivisibleList = new List<Predicate<int>>();
            divisors.ForEach(divisor => isDivisibleList.Add(x => x % divisor == 0));

            var numbers = Enumerable.Range(1, n);
            isDivisibleList.ForEach(predicate => numbers = numbers.ToList().FindAll(predicate));

            Console.WriteLine(string.Join(' ', numbers));
        }
    }
}
