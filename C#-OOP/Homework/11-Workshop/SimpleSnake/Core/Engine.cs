namespace SimpleSnake.Core;

using System;
using System.Diagnostics;
using System.Threading;

using Contracts;
using Enums;
using GameObjects;

public class Engine : IEngine
{
    private readonly Point[] pointsOfDirection;
    private readonly Wall wall;
    private readonly Snake snake;
    private readonly Stopwatch stopwatch;
    private Direction direction;

    private double sleepTime = 100;

    public Engine(Wall wall, Snake snake, Stopwatch stopwatch)
    {
        pointsOfDirection = new Point[4];
        this.wall = wall;
        this.snake = snake;
        this.stopwatch = stopwatch;
    }

    public void Run()
    {
        CreateDirections();
        stopwatch.Start();

        while (true)
        {
            ShowGameStats();

            if (Console.KeyAvailable)
                GetNextDirection();

            if (!snake.IsMoving(pointsOfDirection[(int)direction]))
            {
                stopwatch.Stop();
                AskUserForRestart();
            }

            sleepTime -= 0.01;
            Thread.Sleep((int)sleepTime);
        }
    }

    private void CreateDirections()
    {
        pointsOfDirection[(int)Direction.Right] = new Point(1, 0);
        pointsOfDirection[(int)Direction.Left] = new Point(-1, 0);
        pointsOfDirection[(int)Direction.Down] = new Point(0, 1);
        pointsOfDirection[(int)Direction.Up] = new Point(0, -1);
    }

    private void ShowGameStats()
    {
        Console.SetCursorPosition(wall.LeftX + 1, 0);
        Console.Write($"Score: {snake.Length}");
        Console.SetCursorPosition(wall.LeftX + 1, 1);
        Console.Write($"Game duration: {stopwatch.ElapsedMilliseconds / 60000:d2}:{stopwatch.ElapsedMilliseconds / 1000 % 60:d2}");
    }

    private Direction MapKeyToDirection(ConsoleKey key) 
        => key switch
        {
            ConsoleKey.LeftArrow or ConsoleKey.A => Direction.Left,
            ConsoleKey.RightArrow or ConsoleKey.D => Direction.Right,
            ConsoleKey.UpArrow or ConsoleKey.W => Direction.Up,
            ConsoleKey.DownArrow or ConsoleKey.S => Direction.Down
        };

    private void GetNextDirection()
    {
        Direction keyDirection = MapKeyToDirection(Console.ReadKey(true).Key);

        if ((keyDirection == Direction.Left && direction != Direction.Right)
            || (keyDirection == Direction.Right && direction != Direction.Left)
            || (keyDirection == Direction.Up && direction != Direction.Down)
            || (keyDirection == Direction.Down && direction != Direction.Up))
            direction = keyDirection;

        Console.CursorVisible = false;
    }

    private void AskUserForRestart()
    {
        Console.SetCursorPosition(wall.LeftX + 1, 3);
        Console.Write("Would you like to continue? y/n");
        Console.SetCursorPosition(wall.LeftX + 1, 4);

        if (Console.ReadLine().ToLower()[0] == 'n')
            StopGame();

        Console.Clear();
        StartUp.Main();
    }

    private void StopGame()
    {
        Console.SetCursorPosition(20, 10);
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("Game over!");
        Console.ForegroundColor = ConsoleColor.Black;
        Environment.Exit(0);
    }
}