using System;

namespace SimpleSnake.GameObjects;

public class FoodHash : Food
{
    private const char FoodSymbol = '#';
    private const int Points = 3;
    private const ConsoleColor Color = ConsoleColor.Red;

    public FoodHash(Wall wall) : base(FoodSymbol, Color, wall, Points) { }
}