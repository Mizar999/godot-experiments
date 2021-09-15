using Godot;

public class Box : KinematicBody2D
{
    private Board _board;

    public void Initialize(Board board)
    {
        _board = board;
    }

    public void Push(Vector2 direction)
    {
        Vector2 coord = _board.WorldToMap(Position) + direction.Normalized();
        Vector2 target = _board.MapToWorld(coord);
        GD.Print(coord, _board.IsPassable(coord), Position, target, CanMove(target));

        if (_board.IsPassable(coord) && CanMove(target))
        {
            Position = target;
        }
    }

    private bool CanMove(Vector2 moveTo)
    {
        // TODO Bug: Cannot push box to the right
        Transform2D futureTransform = new Transform2D(Rotation, Position);
        futureTransform.origin = moveTo;
        return !TestMove(futureTransform, Vector2.Zero);
    }
}
