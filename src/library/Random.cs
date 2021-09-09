using Godot;

public static class Random
{
    private static RandomNumberGenerator _generator;

    static Random()
    {
        _generator = new RandomNumberGenerator();
        _generator.Randomize();
    }

    public static float Number()
    {
        return _generator.Randf();
    }

    public static int Number(int from, int to)
    {
        return _generator.RandiRange(from, to);
    }
}