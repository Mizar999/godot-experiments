using Godot;
using Godot.Collections;

public static class ConvertCoordinate
{
    public const int StartX = 42;
    public const int StartY = 52;
    public const int StepX = 24;
    public const int StepY = 36;

    public static Array<int> VectorToArray(Vector2 coordinate)
    {
        return new Array<int>() { (int)((coordinate.x - StartX) / StepX), (int)((coordinate.y - StartY) / StepY)};
    }

    public static Vector2 IndexToVector(int x, int y, int offsetX = 0, int offsetY = 0)
    {
        return new Vector2(StartX + StepX * x + offsetX, StartY + StepY * y + offsetY);
    }
}