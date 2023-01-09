namespace SimpleSnake.GameObjects;

using System;
using System.Collections.Generic;
using System.Linq;

public abstract class Food : Point
{
    private readonly char foodSymbol;
    private readonly ConsoleColor color;
    private readonly Random random;
    private readonly Wall wall;

    protected Food(char foodSymbol, ConsoleColor color, Wall wall, int foodPoints) : base (wall.LeftX, wall.TopY)
    {
        this.foodSymbol = foodSymbol;
        this.color = color;
        this.wall = wall;
        FoodPoints = foodPoints;
        random = new Random();
    }

    public int FoodPoints { get; }

    public void SetRandomPosition(Queue<Point> snakeElements)
    {
        do
        {
            LeftX = random.Next(2, wall.LeftX - 2);
            TopY = random.Next(2, wall.TopY - 2);
        } while (snakeElements.Any(IsAnotherPoint));

        Console.BackgroundColor = color;
        Draw(foodSymbol);
        Console.BackgroundColor = ConsoleColor.White;
    }
}