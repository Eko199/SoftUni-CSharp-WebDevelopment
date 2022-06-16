using System;

namespace _10.MultiplyEvensByOdds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(GetMultipleOfEvenAndOdds(int.Parse(Console.ReadLine())));
        }

        static int GetMultipleOfEvenAndOdds(int number)
        {
            number = Math.Abs(number);
            return GetSumOfEvenDigits(number) * GetSumOfOddDigits(number);
        }

        static int GetSumOfEvenDigits(int number)
        {
            int sum = 0;

            while (number > 0)
            {
                int lastDigit = number % 10;
                if (lastDigit % 2 == 0)
                    sum += lastDigit;

                number /= 10;
            }

            return sum;
        }

        static int GetSumOfOddDigits(int number)
        {
            int sum = 0;

            while (number > 0)
            {
                int lastDigit = number % 10;
                if (lastDigit % 2 == 1)
                    sum += lastDigit;

                number /= 10;
            }

            return sum;
        }
    }
}
