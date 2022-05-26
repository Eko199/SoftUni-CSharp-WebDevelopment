using System;

namespace LeftAndRightSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int leftSum = 0, rightSum = 0;

            for (int i = 0; i < n * 2; i++)
            {
                int x = int.Parse(Console.ReadLine());
                if (i < n)
                    leftSum += x;
                else
                    rightSum += x;
            }

            if (leftSum == rightSum)
                Console.WriteLine($"Yes, sum = {leftSum}");
            else
                Console.WriteLine($"No, diff = {Math.Abs(rightSum - leftSum)}");
        }
    }
}
