using Godot;
using Godot.Collections;

public class PCMove : Node
{
    private Sprite _playerCharacter;
    private Board _board;

    public void Initialize(Board board)
    {
        _board = board;
    }

    public override void _Ready()
    {
        SetProcessUnhandledInput(false);
    }

    public override void _UnhandledInput(InputEvent @event)
    {
        Vector2 coord = _board.WorldToMap(_playerCharacter.Position);

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

        if (_board.IsMovable(coord))
        {
            _playerCharacter.Position = _board.MapToWorld(coord);
        }
    }

    public void _on_InitWorld_SpriteCreated(Sprite newSprite)
    {
        if (newSprite.IsInGroup(GroupName.PlayerCharacter))
        {
            _playerCharacter = newSprite;
            SetProcessUnhandledInput(true);
        }
    }
}
