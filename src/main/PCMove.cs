using Godot;
using System;

public class PCMove : Node
{
    private KinematicBody2D _playerCharacter;
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

        if (_board.IsPassable(coord))
        {
            _playerCharacter.Position = _board.MapToWorld(coord);
        }
    }

    public void OnPlayerCreated(KinematicBody2D body)
    {
        if (!body.IsInGroup(GroupName.PlayerCharacter))
        {
            throw new Exception(string.Format("Expected group '{0}'!", GroupName.PlayerCharacter));
        }

        _playerCharacter = body;
        SetProcessUnhandledInput(true);
    }
}
