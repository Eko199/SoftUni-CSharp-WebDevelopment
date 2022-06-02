using System;

namespace _05.SpecialNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                int sumOfDigits = 0;

                int x = i;
                while (x > 0)
                {
                    sumOfDigits += x % 10;
                    x /= 10;
                }

                Console.WriteLine($"{i} -> {sumOfDigits == 5 || sumOfDigits == 7 || sumOfDigits == 11}");
            }
        }
    }
}
