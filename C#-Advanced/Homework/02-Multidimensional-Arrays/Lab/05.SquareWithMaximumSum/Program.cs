using System;
using System.Linq;

namespace _05.SquareWithMaximumSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int[,] matrix = new int[sizes[0], sizes[1]];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] rowInput = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowInput[col];
                }
            }


            int maxSum = 0;
            int[] maxCoord = { -1, -1 };
            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    int currSum = matrix[row, col] + matrix[row + 1, col] + matrix[row, col + 1] + matrix[row + 1, col + 1];

                    if (currSum > maxSum)
                    {
                        maxSum = currSum;
                        maxCoord = new int[] { row, col };
                    }
                }
            }

            Console.WriteLine(matrix[maxCoord[0], maxCoord[1]] + " " + matrix[maxCoord[0], maxCoord[1] + 1]);
            Console.WriteLine(matrix[maxCoord[0] + 1, maxCoord[1]] + " " + matrix[maxCoord[0] + 1, maxCoord[1] + 1]);
            Console.WriteLine(maxSum);
        }
    }
}
