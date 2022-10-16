using System;
using System.Linq;

namespace _07.PredicateForNames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Predicate<string> isLengthLessOrEqual = str => str.Length <= n;

            Console.WriteLine(string.Join(Environment.NewLine, 
                Array.FindAll(Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray(), isLengthLessOrEqual)));
        }
    }
}
