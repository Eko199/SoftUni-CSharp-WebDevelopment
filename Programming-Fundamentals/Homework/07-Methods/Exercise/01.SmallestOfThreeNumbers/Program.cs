using System;

namespace _01.SmallestOfThreeNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PrintSmallestOfThree(int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()),
                int.Parse(Console.ReadLine()));
        }

        private static void PrintSmallestOfThree(int num1, int num2, int num3)
            => Console.WriteLine(Math.Min(num1, Math.Min(num2, num3)));
    }
}
