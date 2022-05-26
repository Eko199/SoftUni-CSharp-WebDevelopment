using System;

namespace SpecialNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 1111; i < 10000; i++)
            {
                int currentNumber = i;
                bool isSpecial = true;

                while (currentNumber > 0)
                {
                    int currentDigit = currentNumber % 10;
                    if (currentDigit == 0 || n % currentDigit != 0)
                    {
                        isSpecial = false;
                        break;
                    }
                    currentNumber /= 10;
                }

                if (isSpecial)
                    Console.Write(i + " ");
            }
        }
    }
}
