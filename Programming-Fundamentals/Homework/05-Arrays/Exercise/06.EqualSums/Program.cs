using System;
using System.Linq;

namespace _06.EqualSums
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            bool foundNumber = false;
            for (int i = 0; i < numbers.Length; i++)
            {
                int leftSum = numbers.Take(i).Sum();
                int rightSum = numbers.Skip(i + 1).Sum();

                if (leftSum == rightSum)
                {
                    foundNumber = true;
                    Console.WriteLine(i);
                    break;
                }
            }

            if (!foundNumber) Console.WriteLine("no");
        }
    }
}
