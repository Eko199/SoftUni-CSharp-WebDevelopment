using System;

namespace _10.TopNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int end = int.Parse(Console.ReadLine());

            for (int i = 1; i <= end; i++)
            {
                if (IsTopNumber(i)) Console.WriteLine(i);
            }
        }

        private static bool IsTopNumber(int number)
        {
            int sumOfDigits = 0;
            bool hasOddDigit = false;

            while (number > 0)
            {
                int digit = number % 10;
                if (digit % 2 == 1) hasOddDigit = true;
                sumOfDigits += digit;
                number /= 10;
            }

            return hasOddDigit && sumOfDigits % 8 == 0;
        }
    }
}
