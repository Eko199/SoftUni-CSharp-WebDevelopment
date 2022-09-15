using System;
using System.Linq;

namespace _09.Miner
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] field = new char[n, n];
            string[] commands = Console.ReadLine().Split();

            (int, int) minerPos = (-1, -1);
            int coalCount = 0;
            for (int row = 0; row < field.GetLength(0); row++)
            {
                char[] rowValues = Console.ReadLine().Split().Select(char.Parse).ToArray();
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    field[row, col] = rowValues[col];
                    if (field[row, col] == 's') minerPos = (row, col);
                    else if (field[row, col] == 'c') coalCount++;
                }
            }

            bool ended = false;
            foreach (string command in commands)
            {
                switch (command)
                {
                    case "up":
                        if (minerPos.Item1 - 1 >= 0)
                            minerPos = (minerPos.Item1 - 1, minerPos.Item2);
                        break;
                    case "down":
                        if (minerPos.Item1 + 1 < field.GetLength(0))
                            minerPos = (minerPos.Item1 + 1, minerPos.Item2);
                        break;
                    case "right":
                        if (minerPos.Item2 + 1 < field.GetLength(1))
                            minerPos = (minerPos.Item1, minerPos.Item2 + 1);
                        break;
                    case "left":
                        if (minerPos.Item2 - 1 >= 0)
                            minerPos = (minerPos.Item1, minerPos.Item2 - 1);
                        break;
                }

                if (field[minerPos.Item1, minerPos.Item2] == 'e')
                {
                    Console.WriteLine($"Game over! ({minerPos.Item1}, {minerPos.Item2})");
                    ended = true;
                }
                else if (field[minerPos.Item1, minerPos.Item2] == 'c')
                {
                    field[minerPos.Item1, minerPos.Item2] = '*';
                    coalCount--;

                    if (coalCount == 0)
                    {
                        Console.WriteLine($"You collected all coals! ({minerPos.Item1}, {minerPos.Item2})");
                        ended = true;
                    }
                }
            }

            if (!ended) Console.WriteLine($"{coalCount} coals left. ({minerPos.Item1}, {minerPos.Item2})");
        }
    }
}
