using System;

namespace SumNumbers1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstSum = int.Parse(Console.ReadLine());
            int sum = 0;

            while (sum < firstSum)
            {
                sum += int.Parse(Console.ReadLine());
            }

            Console.WriteLine(sum);
        }
    }
}
