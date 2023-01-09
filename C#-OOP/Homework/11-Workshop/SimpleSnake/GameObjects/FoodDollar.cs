using System;

namespace SimpleSnake.GameObjects;

public class FoodDollar : Food
{
    private const char FoodSymbol = '$';
    private const int Points = 2;
    private const ConsoleColor Color = ConsoleColor.Cyan;

    public FoodDollar(Wall wall) : base(FoodSymbol, Color, wall, Points) { }
}