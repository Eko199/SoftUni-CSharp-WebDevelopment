using System;

namespace _03.RecursiveFibonacci
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(GetFibonacci(int.Parse(Console.ReadLine())));
        }

        static int GetFibonacci(int n)
        {
            if (n == 1 || n == 2)
                return 1;
            if (n < 1)
                return -1;

            return GetFibonacci(n - 1) + GetFibonacci(n - 2);
        }
    }
}
