using System;
using System.Linq;

namespace _04.SymbolInMatrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] matrix = new char[size, size];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string rowInput = Console.ReadLine();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowInput[col];
                }
            }

            char symbol = char.Parse(Console.ReadLine());

            bool found = false;
            for (int row = 0; row < matrix.GetLength(0) && !found; row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] != symbol) continue;

                    found = true;
                    Console.WriteLine($"({row}, {col})");
                    break;
                }
            }

            if (!found) Console.WriteLine(symbol + " does not occur in the matrix");
        }
    }
}
