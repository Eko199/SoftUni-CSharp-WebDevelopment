using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.RadioMutantVampireBunnies
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            char[,] lair = new char[sizes[0], sizes[1]];

            (int, int) playerPos = (-1, -1);
            for (int row = 0; row < lair.GetLength(0); row++)
            {
                string rowValues = Console.ReadLine();
                for (int col = 0; col < lair.GetLength(1); col++)
                {
                    lair[row, col] = rowValues[col];
                    if (lair[row, col] == 'P') playerPos = (row, col);
                }
            }

            string commands = Console.ReadLine();
            bool escaped = false, dead = false;

            foreach (var command in commands.TakeWhile(_ => !escaped && !dead))
            {
                lair[playerPos.Item1, playerPos.Item2] = '.';

                switch (command)
                {
                    case 'U':
                        if (playerPos.Item1 == 0)
                        {
                            escaped = true;
                            break;
                        }

                        playerPos = (playerPos.Item1 - 1, playerPos.Item2);
                        break;
                    case 'D':
                        if (playerPos.Item1 == lair.GetLength(0) - 1)
                        {
                            escaped = true;
                            break;
                        }

                        playerPos = (playerPos.Item1 + 1, playerPos.Item2);
                        break;
                    case 'R':
                        if (playerPos.Item2 == lair.GetLength(1) - 1)
                        {
                            escaped = true;
                            break;
                        }

                        playerPos = (playerPos.Item1, playerPos.Item2 + 1);
                        break;
                    case 'L':
                        if (playerPos.Item2 == 0)
                        {
                            escaped = true;
                            break;
                        }

                        playerPos = (playerPos.Item1, playerPos.Item2 - 1);
                        break;
                }

                if (!escaped && lair[playerPos.Item1, playerPos.Item2] == 'B')
                    dead = true;
                else if (!escaped)
                    lair[playerPos.Item1, playerPos.Item2] = 'P';

                for (int row = 0; row < lair.GetLength(0); row++)
                {
                    for (int col = 0; col < lair.GetLength(1); col++)
                    {
                        if (lair[row, col] != 'B') continue;

                        var newBunniesSet = new HashSet<(int, int)>();

                        if (row - 1 >= 0 && lair[row - 1, col] != 'B')
                        {
                            lair[row - 1, col] = 'N'; //N for new bunnies
                            newBunniesSet.Add((row - 1, col));
                        }

                        if (row + 1 < lair.GetLength(0) && lair[row + 1, col] != 'B')
                        {
                            lair[row + 1, col] = 'N'; //N for new bunnies
                            newBunniesSet.Add((row + 1, col));
                        }

                        if (col - 1 >= 0 && lair[row, col - 1] != 'B')
                        {
                            lair[row, col - 1] = 'N'; //N for new bunnies
                            newBunniesSet.Add((row, col - 1));
                        }

                        if (col + 1 < lair.GetLength(1) && lair[row, col + 1] != 'B')
                        {
                            lair[row, col + 1] = 'N'; //N for new bunnies
                            newBunniesSet.Add((row, col + 1));
                        }

                        if (!escaped && !dead && newBunniesSet.Contains(playerPos))
                            dead = true;
                    }
                }

                for (int row = 0; row < lair.GetLength(0); row++)
                {
                    for (int col = 0; col < lair.GetLength(1); col++)
                    {
                        if (lair[row, col] == 'N')
                            lair[row, col] = 'B'; //convert new bunnies to mutant bunnies
                    }
                }
            }

            PrintMatrix(lair);

            if (escaped)
                Console.Write("won: ");
            else if (dead)
                Console.Write("dead: ");

            Console.WriteLine($"{playerPos.Item1} {playerPos.Item2}");
        }

        private static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}
