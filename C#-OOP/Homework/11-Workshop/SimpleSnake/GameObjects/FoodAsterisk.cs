namespace SimpleSnake.GameObjects;

using System;

public class FoodAsterisk : Food
{
    private const char FoodSymbol = '*';
    private const int Points = 1;
    private const ConsoleColor Color = ConsoleColor.Green;

    public FoodAsterisk(Wall wall) : base(FoodSymbol, Color, wall, Points) { }
}