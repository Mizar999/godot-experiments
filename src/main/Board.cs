using Godot;

public class Board : TileMap
{
    public const int MaxX = 40;
    public const int MaxY = 15;

    [Signal]
    public delegate void SpriteCreated(Sprite newSprite);

    private static PackedScene _player = ResourceLoader.Load<PackedScene>("res://sprites/PC.tscn");
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

    public bool IsInside(Vector2 coord)
    {
        return (coord.x > -1) && (coord.x < MaxX) && (coord.y > -1) && (coord.y < MaxY);
    }

    private void InitFloor()
    {
        for(int x = 0; x < MaxX; ++x)
        {
            for(int y = 0; y < MaxY; ++y)
            {
                SetCell(x, y, 0);
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

    private void CreateSprite(PackedScene prefab, string group, int x, int y)
    {
        Sprite newSprite = prefab.Instance<Sprite>();
        newSprite.Position = MapToWorld(new Vector2(x, y));
        newSprite.AddToGroup(group);
        AddChild(newSprite);

        EmitSignal(nameof(SpriteCreated), newSprite);
    }
}
