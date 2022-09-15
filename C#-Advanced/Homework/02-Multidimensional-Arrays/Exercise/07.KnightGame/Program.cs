using System;
using System.Linq;

namespace _07.KnightGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] table = new char[n, n];
            
            for (int row = 0; row < table.GetLength(0); row++)
            {
                string rowValues = Console.ReadLine();
                for (int col = 0; col < table.GetLength(1); col++)
                {
                    table[row, col] = rowValues[col];
                }
            }

            int removed = 0, maxAttacked;
            do
            {
                maxAttacked = 0;
                (int, int) maxAttackedCoord = (-1, -1);

                for (int row = 0; row < table.GetLength(0); row++)
                {
                    for (int col = 0; col < table.GetLength(1); col++)
                    {
                        if (table[row, col] != 'K') continue;

                        int currAttackCount = CountAttackingKnights(table, row, col);
                        if (maxAttacked < currAttackCount)
                        {
                            maxAttacked = currAttackCount;
                            maxAttackedCoord = (row, col);
                        }
                    }
                }

                if (maxAttackedCoord.Item1 != -1 && maxAttackedCoord.Item2 != -1)
                {
                    table[maxAttackedCoord.Item1, maxAttackedCoord.Item2] = '0';
                    removed++;
                }
            } while (maxAttacked > 0);

            Console.WriteLine(removed);
        }

        private static int CountAttackingKnights(char[,] table, int row, int col)
        {
            if (table[row, col] != 'K') return -1;

            int attacks = 0;

            if (row - 2 >= 0 && col - 1 >= 0 && table[row - 2, col - 1] == 'K')
                attacks++;
            if (row - 2 >= 0 && col + 1 < table.GetLength(1) && table[row - 2, col + 1] == 'K')
                attacks++;
            if (row + 2 < table.GetLength(0) && col - 1 >= 0 && table[row + 2, col - 1] == 'K')
                attacks++;
            if (row + 2 < table.GetLength(0) && col + 1 < table.GetLength(1) && table[row + 2, col + 1] == 'K')
                attacks++;

            if (row - 1 >= 0 && col - 2 >= 0 && table[row - 1, col - 2] == 'K')
                attacks++;
            if (row - 1 >= 0 && col + 2 < table.GetLength(1) && table[row - 1, col + 2] == 'K')
                attacks++;
            if (row + 1 < table.GetLength(0) && col - 2 >= 0 && table[row + 1, col - 2] == 'K')
                attacks++;
            if (row + 1 < table.GetLength(0) && col + 2 < table.GetLength(1) && table[row + 1, col + 2] == 'K')
                attacks++;

            return attacks;
        }
    }
}
