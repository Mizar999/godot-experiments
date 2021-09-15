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
        Vector2 coord = _board.WorldToMap(Position) + direction;
        if (_board.IsPassable(coord))
        {
            Vector2 oldPosition = Position;
            KinematicCollision2D collision = MoveAndCollide(direction * Board.TileSize);
            if (collision != null)
            {
                Position = oldPosition;
            }
        }
    }
}
