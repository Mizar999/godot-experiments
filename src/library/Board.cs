public static class Board
{
    public const int MaxX = 40;
    public const int MaxY = 15;

    public static bool IsInsideBoard(int x, int y)
    {
        return (x > -1) && (x < MaxX) && (y > -1) && (y < MaxY);
    }
}