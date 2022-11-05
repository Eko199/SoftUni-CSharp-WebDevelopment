using System;

namespace _02.RecursiveFactorial
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Factorial(int.Parse(Console.ReadLine())));
        }

        private static long Factorial(int n)
            => n * (n > 1 ? Factorial(n - 1) : 1);
    }
}
