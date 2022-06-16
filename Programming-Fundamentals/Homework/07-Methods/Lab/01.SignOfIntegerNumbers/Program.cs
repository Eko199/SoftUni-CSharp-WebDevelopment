using System;

namespace _01._Sign_of_Integer_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PrintSign(int.Parse(Console.ReadLine()));
        }

        static void PrintSign(int number)
        {
            if (number < 0)
                Console.WriteLine($"The number {number} is negative. ");
            else if (number > 0)
                Console.WriteLine($"The number {number} is positive. ");
            else
                Console.WriteLine($"The number {number} is zero. ");
        }
    }
}
