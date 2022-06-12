using System;
using System.Linq;

namespace _06.EvenAndOddSubtraction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int[] sums = { 0, 0 };
            foreach (int number in numbers)
            {
                sums[number % 2] += number;
            }
            Console.WriteLine(sums[0] - sums[1]);
        }
    }
}
