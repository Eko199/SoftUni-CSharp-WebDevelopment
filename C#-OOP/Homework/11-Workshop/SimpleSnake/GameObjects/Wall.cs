namespace SimpleSnake.GameObjects;

public class Wall : Point
{
    private const char WallSymbol = '\u25A0';

    public Wall(int leftX, int topY) : base(leftX, topY)
    {
        InitializeWallBorders();
    }

    public bool IsPointOfWall(Point point) 
        => point.TopY == 0 || point.LeftX == 0 || point.LeftX == LeftX - 1 || point.TopY == TopY;

    private void SetHorizontalLine(int topY)
    {
        for (int leftX = 0; leftX < LeftX; leftX++)
        {
            Draw(leftX, topY, WallSymbol);
        }
    }

    private void SetVerticalLine(int leftX)
    {
        for (int topY = 0; topY < TopY; topY++)
        {
            Draw(leftX, topY, WallSymbol);
        }
    }

    private void InitializeWallBorders()
    {
        SetHorizontalLine(0);
        SetHorizontalLine(TopY);

        SetVerticalLine(0);
        SetVerticalLine(LeftX - 1);
    }
}