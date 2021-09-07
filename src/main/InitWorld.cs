using Godot;

public class InitWorld : Node
{
    [Signal]
    public delegate void SpriteCreated(Sprite newSprite);

    private static PackedScene _player = ResourceLoader.Load<PackedScene>("res://sprites/PC.tscn");
    private static PackedScene _floor = ResourceLoader.Load<PackedScene>("res://sprites/Floor.tscn");
    private static PackedScene _target = ResourceLoader.Load<PackedScene>("res://sprites/Target.tscn");
    private static PackedScene _box = ResourceLoader.Load<PackedScene>("res://sprites/Box.tscn");

    public override void _UnhandledInput(InputEvent @event)
    {
        if (@event.IsActionPressed(InputName.InitWorld))
        {
            InitFloor();
            InitPlayerCharacter();
            InitTarget();
            InitBox();
            SetProcessUnhandledInput(false);
        }
    }

    private void InitFloor()
    {
        for (int x = 0; x < Board.MaxX; ++x)
        {
            for (int y = 0; y < Board.MaxY; ++y)
            {
                CreateSprite(_floor, GroupName.Floor, x, y);
            }
        }
    }

    private void InitPlayerCharacter()
    {
        CreateSprite(_player, GroupName.PlayerCharacter, 0, 0);
    }

    private void InitTarget()
    {
        CreateSprite(_target, GroupName.Target, 3, 3);
        CreateSprite(_target, GroupName.Target, 3, Board.MaxY - 3);
    }

    private void InitBox()
    {
        CreateSprite(_box, GroupName.Box, Board.MaxX - 5, 5);
        CreateSprite(_box, GroupName.Box, Board.MaxX - 5, Board.MaxY - 5);
    }

    private void CreateSprite(PackedScene prefab, string group, int x, int y, int offsetX = 0, int offsetY = 0)
    {
        Sprite newSprite = prefab.Instance<Sprite>();
        newSprite.Position = ConvertCoordinate.IndexToVector(x, y, offsetX, offsetY);
        newSprite.AddToGroup(group);
        AddChild(newSprite);

        EmitSignal(nameof(SpriteCreated), newSprite);
    }
}
