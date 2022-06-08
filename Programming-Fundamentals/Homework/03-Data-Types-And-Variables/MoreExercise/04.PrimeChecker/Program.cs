using System;

namespace _04.PrimeChecker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            for (int number = 2; number <= count; number++)
            {
                bool isPrime = true;
                for (int divisor = 2; divisor < number; divisor++)
                {
                    if (number % divisor == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }

                Console.WriteLine("{0} -> {1}", number, isPrime.ToString().ToLower());
            }
        }
    }
}
