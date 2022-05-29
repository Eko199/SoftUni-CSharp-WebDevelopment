using System;

namespace _06.StrongNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int original = number, sum = 0;
            while (number > 0)
            {
                sum += Factoriel(number % 10);
                number /= 10;
            }

            Console.WriteLine(sum == original ? "yes" : "no");
        }

        static int Factoriel(int x)
        {
            int result = 1;
            for (int i = 2; i <= x; i++)
                result *= i;
            return result;
        }
    }
}
