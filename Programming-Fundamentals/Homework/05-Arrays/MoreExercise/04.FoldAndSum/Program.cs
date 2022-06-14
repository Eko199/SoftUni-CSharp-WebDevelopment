using System;
using System.Linq;

namespace _04.FoldAndSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int[] topRow = new int[numbers.Length / 2];
            int[] downRow = new int[numbers.Length / 2];

            for (int i = 0; i < numbers.Length / 4; i++)
            {
                topRow[i] = numbers[numbers.Length / 4 - 1 - i];
                downRow[i] = numbers[numbers.Length / 4 + i];

                topRow[^(i + 1)] = numbers[numbers.Length * 3 / 4 + i];
                downRow[^(i + 1)] = numbers[numbers.Length * 3 / 4 - 1 - i];
            }

            int[] sums = topRow.Select((x, index) => x + downRow[index]).ToArray();
            Console.WriteLine(string.Join(' ', sums));
        }
    }
}
