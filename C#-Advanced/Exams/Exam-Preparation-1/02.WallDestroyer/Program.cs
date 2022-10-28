using System;

namespace _02.WallDestroyer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] wall = new char[n, n];

            (int Row, int Col) currentPos = (-1, -1);

            for (int row = 0; row < wall.GetLength(0); row++)
            {
                string rowInfo = Console.ReadLine();
                for (int col = 0; col < wall.GetLength(1); col++)
                {
                    wall[row, col] = rowInfo[col];

                    if (rowInfo[col] == 'V')
                    {
                        currentPos = (row, col);
                        wall[row, col] = '*';
                    }
                }
            }

            int holes = 1, rodHits = 0;
            bool gotElectrocuted = false;

            string command;
            while ((command = Console.ReadLine()) != "End" && !gotElectrocuted)
            {
                (int Row, int Col) newPos = command switch
                {
                    "up" => (currentPos.Row - 1, currentPos.Col),
                    "down" => (currentPos.Row + 1, currentPos.Col),
                    "right" => (currentPos.Row, currentPos.Col + 1),
                    "left" => (currentPos.Row, currentPos.Col - 1)
                };

                if (newPos.Row < 0 || newPos.Col < 0 || newPos.Row >= wall.GetLength(0) || newPos.Col >= wall.GetLength(1))
                    continue;

                switch (wall[newPos.Row, newPos.Col])
                {
                    case 'R':
                        rodHits++;
                        Console.WriteLine("Vanko hit a rod!");
                        break;
                    case 'C':
                        holes++;
                        currentPos = newPos;
                        gotElectrocuted = true;
                        break;
                    case '*':
                        currentPos = newPos;
                        Console.WriteLine($"The wall is already destroyed at position [{newPos.Row}, {newPos.Col}]!");
                        break;
                    default:
                        holes++;
                        currentPos = newPos;
                        wall[currentPos.Row, currentPos.Col] = '*';
                        break;
                }
            }

            Console.WriteLine(gotElectrocuted 
                ? $"Vanko got electrocuted, but he managed to make {holes} hole(s)." 
                : $"Vanko managed to make {holes} hole(s) and he hit only {rodHits} rod(s).");

            wall[currentPos.Row, currentPos.Col] = gotElectrocuted ? 'E' : 'V';

            PrintMatrix(wall);
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
