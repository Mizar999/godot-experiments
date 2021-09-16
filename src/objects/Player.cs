using Godot;

public class Player : KinematicBody2D
{
    private Board _board;
    private Vector2 _currentDirection = Vector2.Zero;
    private float _waitMove;

    private readonly float _waitMoveResetValue = 0.08f;

    public void Initialize(Board board)
    {
        _board = board;
    }

    public override void _Process(float delta)
    {
        if (_waitMove > 0)
        {
            _waitMove -= delta;
        }
    }

    public override void _UnhandledInput(InputEvent @event)
    {
        UpdateCurrentDirection(@event);

        if (_waitMove > 0)
        {
            return;
        }

        if (_currentDirection != Vector2.Zero)
        {
            if (_board.IsPassable(_board.WorldToMap(Position) + _currentDirection))
            {
                Vector2 oldPosition = Position;
                Vector2 movement = _currentDirection * Board.TileSize;
                KinematicCollision2D collision = MoveAndCollide(movement);
                if (collision != null)
                {
                    Position = oldPosition;
                    Box box = collision.Collider as Box;
                    if (box != null)
                    {
                        if (box.Push(_currentDirection))
                        {
                            Translate(movement);
                        }
                    }
                }

                if (Position != oldPosition)
                {
                    _waitMove = _waitMoveResetValue;
                }
            }
        }
    }

    private void UpdateCurrentDirection(InputEvent @event)
    {
        if (@event.IsActionPressed(InputName.MoveLeft))
        {
            _currentDirection = Vector2.Left;
        }
        else if (@event.IsActionPressed(InputName.MoveRight))
        {
            _currentDirection = Vector2.Right;
        }
        else if (@event.IsActionPressed(InputName.MoveUp))
        {
            _currentDirection = Vector2.Up;
        }
        else if (@event.IsActionPressed(InputName.MoveDown))
        {
            _currentDirection = Vector2.Down;
        }

        if (!@event.IsPressed())
        {
            _currentDirection = Vector2.Zero;
        }
    }
}
