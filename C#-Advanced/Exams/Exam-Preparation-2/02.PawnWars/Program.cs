using System;

namespace _02.PawnWars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[,] board = new char[8, 8];
            (int Row, int Col) whitePos = (-1, -1), blackPos = (-1, -1);

            for (int row = 0; row < board.GetLength(0); row++)
            {
                string rowInfo = Console.ReadLine();

                for (int col = 0; col < board.GetLength(1); col++)
                {
                    board[row, col] = rowInfo[col];

                    if (board[row, col] == 'w')
                        whitePos = (row, col);
                    else if (board[row, col] == 'b')
                        blackPos = (row, col);
                }
            }

            while (true)
            {
                if (blackPos == (whitePos.Row - 1, whitePos.Col + 1) ||
                    blackPos == (whitePos.Row - 1, whitePos.Col - 1))
                {
                    Console.WriteLine($"Game over! White capture on {(char) (blackPos.Col + 97)}{8 - blackPos.Row}.");
                    break;
                }

                whitePos = (whitePos.Row - 1, whitePos.Col);
                if (whitePos.Row == 0)
                {
                    Console.WriteLine(
                        $"Game over! White pawn is promoted to a queen at {(char)(whitePos.Col + 97)}{8 - whitePos.Row}.");
                    break;
                }

                if (whitePos == (blackPos.Row + 1, blackPos.Col + 1) ||
                    whitePos == (blackPos.Row + 1, blackPos.Col - 1))
                {
                    Console.WriteLine($"Game over! Black capture on {(char) (whitePos.Col + 97)}{8 - whitePos.Row}.");
                    break;
                }

                blackPos = (blackPos.Row + 1, blackPos.Col);
                if (blackPos.Row == 7)
                {
                    Console.WriteLine(
                        $"Game over! Black pawn is promoted to a queen at {(char) (blackPos.Col + 97)}{8 - blackPos.Row}.");
                    break;
                }
            }
        }
    }
}
