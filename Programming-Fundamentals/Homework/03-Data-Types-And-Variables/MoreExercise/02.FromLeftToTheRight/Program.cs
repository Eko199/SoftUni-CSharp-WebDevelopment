using System;

namespace _02.FromLeftToTheRight
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                string input = Console.ReadLine();
                long x = long.Parse(input.Split(' ')[0]);
                long y = long.Parse(input.Split(' ')[1]);

                Console.WriteLine(sumOfDigits(Math.Max(x, y)));
            }
        }

        static int sumOfDigits(long number)
        {
            int sum = 0;
            while (number != 0)
            {
                sum += (int) (number % 10);
                number /= 10;
            }
            return Math.Abs(sum);
        }
    }
}
