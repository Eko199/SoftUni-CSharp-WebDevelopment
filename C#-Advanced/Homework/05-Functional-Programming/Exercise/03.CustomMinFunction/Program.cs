using System;
using System.Linq;

namespace _03.CustomMinFunction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<int[], int> min = arr =>
            {
                int min = int.MaxValue;

                foreach (int x in arr)
                {
                    if (x < min) min = x;
                }

                return min;
            };

            Console.WriteLine(
                min(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray()));
        }
    }
}
