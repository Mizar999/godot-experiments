using Godot;
using Godot.Collections;

public class PCMove : Node
{
    private Sprite _playerCharacter;

    public override void _Ready()
    {
        SetProcessUnhandledInput(false);
    }

    public override void _UnhandledInput(InputEvent @event)
    {
        Array<int> coords = ConvertCoordinate.VectorToArray(_playerCharacter.Position);
        int x = coords[0];
        int y = coords[1];

        if (@event.IsActionPressed(InputName.MoveLeft))
        {
            x -= 1;
        }
        else if (@event.IsActionPressed(InputName.MoveRight))
        {
            x += 1;
        }
        else if (@event.IsActionPressed(InputName.MoveUp))
        {
            y -= 1;
        }
        else if (@event.IsActionPressed(InputName.MoveDown))
        {
            y += 1;
        }

        _playerCharacter.Position = ConvertCoordinate.IndexToVector(x, y);
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
