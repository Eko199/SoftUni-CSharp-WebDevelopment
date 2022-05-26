using System;

namespace SumOfTwoNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());
            int number = int.Parse(Console.ReadLine());
            bool foundCombination = false;

            for (int i = start; i <= end; i++)
            {
                for (int j = start; j <= end; j++)
                {
                    if (i + j == number)
                    {
                        Console.WriteLine($"Combination N:{(i-start+1)*(j-start+1)} ({i} + {j} = {number})");
                        foundCombination = true;
                        break;
                    }
                }
                if (foundCombination)
                    break;
            }

            if (!foundCombination)
                Console.WriteLine($"{(end - start + 1) * (end - start + 1)} combinations - neither equals {number}");
        }
    }
}
