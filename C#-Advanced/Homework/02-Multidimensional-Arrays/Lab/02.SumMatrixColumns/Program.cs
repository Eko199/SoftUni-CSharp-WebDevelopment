﻿using System;
using System.Linq;

namespace _02.SumMatrixColumns
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int[,] matrix = new int[sizes[0], sizes[1]];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] rowInput = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowInput[col];
                }
            }

            int[] colSum = new int[matrix.GetLength(0)];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    colSum[col] += matrix[row, col];
                }
            }

            Console.WriteLine(string.Join(Environment.NewLine, colSum));
        }
    }
}
