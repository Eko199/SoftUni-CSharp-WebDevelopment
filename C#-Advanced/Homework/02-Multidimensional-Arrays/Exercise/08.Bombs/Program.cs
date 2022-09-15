using System;
using System.Linq;

namespace _08.Bombs
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

            (int, int)[] bombs = Console.ReadLine()
                                        .Split()
                                        .Select(coordinates =>
                                        (int.Parse(coordinates.Split(',')[0]), int.Parse(coordinates.Split(',')[1])))
                                        .ToArray();

            foreach ((int, int) bomb in bombs)
            {
                int damage = matrix[bomb.Item1, bomb.Item2];
                if (damage <= 0) continue;

                if (bomb.Item1 - 1 >= 0)
                {
                    if (matrix[bomb.Item1 - 1, bomb.Item2] > 0)
                        matrix[bomb.Item1 - 1, bomb.Item2] -= damage;
                    if (bomb.Item2 - 1 >= 0 && matrix[bomb.Item1 - 1, bomb.Item2 - 1] > 0)
                        matrix[bomb.Item1 - 1, bomb.Item2 - 1] -= damage;
                    if (bomb.Item2 + 1 < matrix.GetLength(1) && matrix[bomb.Item1 - 1, bomb.Item2 + 1] > 0)
                        matrix[bomb.Item1 - 1, bomb.Item2 + 1] -= damage;
                }

                if (bomb.Item1 + 1 < matrix.GetLength(0))
                {
                    if (matrix[bomb.Item1 + 1, bomb.Item2] > 0)
                        matrix[bomb.Item1 + 1, bomb.Item2] -= damage;
                    if (bomb.Item2 - 1 >= 0 && matrix[bomb.Item1 + 1, bomb.Item2 - 1] > 0)
                        matrix[bomb.Item1 + 1, bomb.Item2 - 1] -= damage;
                    if (bomb.Item2 + 1 < matrix.GetLength(1) && matrix[bomb.Item1 + 1, bomb.Item2 + 1] > 0)
                        matrix[bomb.Item1 + 1, bomb.Item2 + 1] -= damage;
                }

                if (bomb.Item2 - 1 >= 0 && matrix[bomb.Item1, bomb.Item2 - 1] > 0)
                    matrix[bomb.Item1, bomb.Item2 - 1] -= damage;
                if (bomb.Item2 + 1 < matrix.GetLength(1) && matrix[bomb.Item1, bomb.Item2 + 1] > 0)
                    matrix[bomb.Item1, bomb.Item2 + 1] -= damage;

                matrix[bomb.Item1, bomb.Item2] = 0;
            }

            int aliveCount = 0, aliveSum = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] <= 0) continue;

                    aliveCount++;
                    aliveSum += matrix[row, col];
                }
            }

            Console.WriteLine("Alive cells: " + aliveCount);
            Console.WriteLine("Sum: " + aliveSum);
            PrintMatrix(matrix);
        }

        private static void PrintMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
