using System;

namespace _07.PascalTriangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            long[][] pascal = new long[n][];

            for (int row = 0; row < pascal.Length; row++)
            {
                pascal[row] = new long[row + 1];
                pascal[row][0] = pascal[row][pascal[row].Length - 1] = 1;

                for (int i = 1; i < pascal[row].Length - 1; i++)
                {
                    pascal[row][i] = pascal[row - 1][i - 1] + pascal[row - 1][i];
                }
            }

            foreach (long[] row in pascal)
            {
                Console.WriteLine(string.Join(' ', row));
            }
        }
    }
}
