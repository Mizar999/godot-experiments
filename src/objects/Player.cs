using Godot;
using System;

public class Player : KinematicBody2D
{
    private Board _board;

    public void Initialize(Board board)
    {
        _board = board;
    }

    public override void _UnhandledInput(InputEvent @event)
    {
        Vector2 coord = _board.WorldToMap(Position);

        if (@event.IsActionPressed(InputName.MoveLeft))
        {
            coord.x -= 1;
        }
        else if (@event.IsActionPressed(InputName.MoveRight))
        {
            coord.x += 1;
        }
        else if (@event.IsActionPressed(InputName.MoveUp))
        {
            coord.y -= 1;
        }
        else if (@event.IsActionPressed(InputName.MoveDown))
        {
            coord.y += 1;
        }

        Vector2 worldCoord = _board.MapToWorld(coord);
        if (Position != worldCoord && _board.IsPassable(coord) && CanMove(worldCoord))
        {
            Position = worldCoord;
        }
    }

    private bool CanMove(Vector2 target)
    {
        // TODO Fix me
        Transform2D futureTransform = new Transform2D(Rotation, Position);
        futureTransform.origin = target;
        GD.Print(Transform.x, Transform.y, Transform.origin, futureTransform.x, futureTransform.y, futureTransform.origin);
        return !TestMove(futureTransform, Vector2.Zero);
    }
}
