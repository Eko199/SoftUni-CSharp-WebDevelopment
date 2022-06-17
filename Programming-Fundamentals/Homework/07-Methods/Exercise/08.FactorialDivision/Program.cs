using System;

namespace _08.FactorialDivision
{
    internal class Program
    {
        static void Main(string[] args)
        {
            long factorial1 = Factorial(int.Parse(Console.ReadLine()));
            long factorial2 = Factorial(int.Parse(Console.ReadLine()));
            Console.WriteLine($"{1.0 * factorial1 / factorial2 :f2}");
        }

        private static long Factorial(int number)
        {
            long result = 1;

            for (int i = 2; i <= number; i++)
            {
                result *= i;
            }

            return result;
        }
    }
}
