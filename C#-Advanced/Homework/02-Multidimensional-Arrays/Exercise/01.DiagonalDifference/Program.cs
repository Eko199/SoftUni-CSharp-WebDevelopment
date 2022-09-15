using System;
using System.Linq;

namespace _01.DiagonalDifference
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] rowValues = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowValues[col];
                }
            }

            int primeDiagonal = 0, secondaryDiagonal = 0;
            for (int i = 0; i < n; i++)
            {
                primeDiagonal += matrix[i, i];
                secondaryDiagonal += matrix[i, n - 1 - i];
            }

            Console.WriteLine(Math.Abs(primeDiagonal - secondaryDiagonal));
        }
    }
}
