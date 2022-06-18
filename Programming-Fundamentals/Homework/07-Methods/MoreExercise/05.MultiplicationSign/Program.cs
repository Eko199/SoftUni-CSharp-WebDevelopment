using System;

namespace _05.MultiplicationSign
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());

            int negativeCount = GetNegativeCount(num1, num2, num3);
            Console.WriteLine(negativeCount % 2 == 0 ? "positive" : negativeCount % 2 == 1 ? "negative" : "zero");
        }

        private static int GetNegativeCount(int num1, int num2, int num3)
        {
            if (num1 == 0 || num2 == 0 || num3 == 0) return -1;

            int count = 0;

            if (num1 < 0)
                count++;
            if (num2 < 0)
                count++;
            if (num3 < 0)
                count++;

            return count;
        }
    }
}
