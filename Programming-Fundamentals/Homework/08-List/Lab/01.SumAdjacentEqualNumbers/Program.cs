using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.SumAdjacentEqualNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<double> numbers = Console.ReadLine().Split().Select(double.Parse).ToList();

            for (int i = 1; i < numbers.Count; i++)
            {
                if (numbers[i] == numbers[i - 1])
                {
                    numbers[i - 1] *= 2;
                    numbers.RemoveAt(i);
                    i = Math.Max(0, i - 2);
                }
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
