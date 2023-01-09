namespace SimpleSnake.GameObjects;

using System;

public class Point
{
    public Point(int leftX, int topY)
    {
        LeftX = leftX;
        TopY = topY;
    }

    public int LeftX { get; set; }
    public int TopY { get; set; }

    public void Draw(char symbol) => Draw(LeftX, TopY, symbol);

    public void Draw(int leftX, int topY, char symbol)
    {
        Console.SetCursorPosition(leftX, topY);
        Console.Write(symbol);
    }

    public bool IsAnotherPoint(Point point) => point.TopY == TopY && point.LeftX == LeftX;
}