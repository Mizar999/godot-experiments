using Godot;

public class Player : KinematicBody2D
{
    private Board _board;

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
            if (_board.IsPassable(_board.WorldToMap(Position) + direction))
            {
                Vector2 oldPosition = Position;
                KinematicCollision2D collision = MoveAndCollide(direction * Board.TileSize);
                if (collision != null)
                {
                    Position = oldPosition;
                    Box box = collision.Collider as Box;
                    if (box != null)
                    {
                        box.Push(direction);
                    }
                }
            }
        }
    }
}
