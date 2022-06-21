using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.RemoveNegativesAndReverse
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            numbers.RemoveAll(n => n < 0);
            numbers.Reverse();
            Console.WriteLine(numbers.Count > 0 ? string.Join(" ", numbers) : "empty");
        }
    }
}
