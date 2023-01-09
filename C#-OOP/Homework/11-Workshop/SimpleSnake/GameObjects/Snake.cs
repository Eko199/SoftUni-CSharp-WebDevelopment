namespace SimpleSnake.GameObjects;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class Snake
{
    private const char SnakeSymbol = '\u25CF';
    private const char EmptySpace = ' ';
    private const int DefaultStartLength = 6;

    private readonly Queue<Point> snakeElements;
    private readonly Wall wall;
    private readonly Random random;
    private readonly IList<Food> food;
    
    private int foodIndex;
    private int nextLeftX, nextTopY;

    public Snake(Wall wall, int startLength = DefaultStartLength)
    {
        this.wall = wall;
        snakeElements = new Queue<Point>();
        random = new Random();
        food = new List<Food>();

        GetFoods();
        foodIndex = RandomFoodIndex;

        CreateSnake(startLength);
        food[foodIndex].SetRandomPosition(snakeElements);
    }

    public int Length => snakeElements.Count;

    public bool IsMoving(Point direction)
    {
        GetNextPoint(direction);
        var nextHead = new Point(nextLeftX, nextTopY);

        if (snakeElements.Any(s => s.IsAnotherPoint(nextHead)) || wall.IsPointOfWall(nextHead))
            return false;

        snakeElements.Enqueue(nextHead);
        nextHead.Draw(SnakeSymbol);

        if (food[foodIndex].IsAnotherPoint(nextHead))
            Eat(direction);

        snakeElements.Dequeue().Draw(EmptySpace);
        return true;
    }

    private void CreateSnake(int startLength)
    {
        for (int topY = 1; topY <= startLength; topY++)
        {
            snakeElements.Enqueue(new Point(2, topY));
        }
    }

    private void GetFoods()
    {
        var foodTypes = Assembly.GetEntryAssembly()
            .GetTypes()
            .Where(t => typeof(Food).IsAssignableFrom(t) && !t.IsAbstract);

        foreach (Type foodType in foodTypes)
        {
            food.Add((Food)Activator.CreateInstance(foodType, wall));
        }
    }

    private void GetNextPoint(Point direction)
    {
        Point snakeHead = snakeElements.Last();

        nextLeftX = direction.LeftX + snakeHead.LeftX;
        nextTopY = direction.TopY + snakeHead.TopY;
    }

    private int RandomFoodIndex => random.Next(0, food.Count);

    private void Eat(Point direction)
    {
        for (int i = 0; i < food[foodIndex].FoodPoints; i++)
        {
            GetNextPoint(direction);
            var newHead = new Point(nextLeftX, nextTopY);
            snakeElements.Enqueue(newHead);
            newHead.Draw(SnakeSymbol);
        }

        foodIndex = RandomFoodIndex;
        food[foodIndex].SetRandomPosition(snakeElements);
    }
}