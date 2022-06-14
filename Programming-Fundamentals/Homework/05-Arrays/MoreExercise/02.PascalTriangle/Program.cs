using System;

namespace _02.PascalTriangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            int[] topRow = { 1 };
            for (int i = 0; i < rows; i++)
            {
                Console.WriteLine(string.Join(' ', topRow));

                int[] currRow = new int[topRow.Length + 1];
                currRow[0] = topRow[0];

                for (int j = 1; j < topRow.Length; j++)
                {
                    currRow[j] = topRow[j - 1] + topRow[j];
                }

                currRow[topRow.Length] = topRow[^1];
                topRow = currRow;
            }
        }
    }
}
