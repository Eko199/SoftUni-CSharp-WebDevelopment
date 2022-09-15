using System;
using System.Linq;

namespace _03.MaximalSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[,] matrix = new int[sizes[0], sizes[1]];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] rowInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowInput[col];
                }
            }

            int maxSum = 0;
            (int, int) maxCoord = (0, 0);
            for (int row = 0; row < matrix.GetLength(0) - 2; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 2; col++)
                {
                    int currSum = matrix[row, col] + matrix[row + 1, col] + matrix[row + 2, col]
                                  + matrix[row, col + 1] + matrix[row + 1, col + 1] + matrix[row + 2, col + 1]
                                  + matrix[row, col + 2] + matrix[row + 1, col + 2] + matrix[row + 2, col + 2];

                    if (currSum > maxSum)
                    {
                        maxSum = currSum;
                        maxCoord = (row, col);
                    }
                }
            }

            Console.WriteLine("Sum = " + maxSum);

            Console.WriteLine(matrix[maxCoord.Item1, maxCoord.Item2] + " " 
                            + matrix[maxCoord.Item1, maxCoord.Item2 + 1] + " " 
                            + matrix[maxCoord.Item1, maxCoord.Item2 + 2]);
            Console.WriteLine(matrix[maxCoord.Item1 + 1, maxCoord.Item2] + " "
                            + matrix[maxCoord.Item1 + 1, maxCoord.Item2 + 1] + " "
                            + matrix[maxCoord.Item1 + 1, maxCoord.Item2 + 2]);
            Console.WriteLine(matrix[maxCoord.Item1 + 2, maxCoord.Item2] + " "
                            + matrix[maxCoord.Item1 + 2, maxCoord.Item2 + 1] + " "
                            + matrix[maxCoord.Item1 + 2, maxCoord.Item2 + 2]);
        }
    }
}
