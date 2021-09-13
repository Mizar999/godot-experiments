using Godot;

public class Player : Area2D
{
    private Board _board;
    private RayCast2D _raycast;

    public override void _Ready()
    {
        _raycast = GetNode<RayCast2D>("RayCast2D");
    }

    public void Initialize(Board board)
    {
        _board = board;
    }

    public override void _UnhandledInput(InputEvent @event)
    {
        Vector2 direction = Vector2.Zero;

        if (@event.IsActionPressed(InputName.MoveLeft))
        {
            direction = Vector2.Left;
        }
        else if (@event.IsActionPressed(InputName.MoveRight))
        {
            direction = Vector2.Right;
        }
        else if (@event.IsActionPressed(InputName.MoveUp))
        {
            direction = Vector2.Up;
        }
        else if (@event.IsActionPressed(InputName.MoveDown))
        {
            direction = Vector2.Down;
        }

        if (direction != Vector2.Zero)
        {
            Vector2 coord = _board.WorldToMap(Position);
            if (_board.IsPassable(coord + direction) && CanMoveToDirection(direction))
            {
                Position = _board.MapToWorld(coord + direction);
            }
        }
    }

    private bool CanMoveToDirection(Vector2 direction)
    {
        _raycast.CastTo = direction * Board.RayCastLength;
        _raycast.ForceRaycastUpdate();
        return !_raycast.IsColliding();
    }
}
