using System;

namespace _02.EnterNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int start = 1, end = 100;
            var numbers = new int[10];

            for (int i = 0; i < 10; i++)
            {
                try
                {
                    numbers[i] = ReadNumber(i == 0 ? start : numbers[i - 1], end);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                    i--;
                }
            }

            Console.WriteLine(string.Join(", ", numbers));
        }

        private static int ReadNumber(int start, int end)
        {
            try
            {
                int x = int.Parse(Console.ReadLine());

                if (x <= start || x >= end)
                    throw new ArgumentException($"Your number is not in range {start} - {end}!");

                return x;
            }
            catch (FormatException fe)
            {
                throw new ArgumentException("Invalid Number!", fe);
            }
        }
    }
}
