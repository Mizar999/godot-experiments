using Godot;

public static class ConvertCoordinate
{
    public const int START_X = 42;
    public const int START_Y = 52;
    public const int STEP_X = 24;
    public const int STEP_Y = 36;

    public static int[] vectorToArray(Vector2 coordinate)
    {
        int[] result = new int[2];
        result[0] = (int)((coordinate.x - START_X) / STEP_X);
        result[1] = (int)((coordinate.y - START_Y) / STEP_Y);
        return result;
    }

    public static Vector2 indexToVector(int x, int y, int offsetX = 0, int offsetY = 0)
    {
        return new Vector2(START_X + STEP_X * x + offsetX, START_Y + STEP_Y * y + offsetY);
    }
}