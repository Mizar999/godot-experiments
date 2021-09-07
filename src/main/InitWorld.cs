using Godot;

public class InitWorld : Node
{
    [Signal]
    public delegate void SpriteCreated(Sprite newSprite);

    private static PackedScene _player = ResourceLoader.Load<PackedScene>("res://sprites/PC.tscn");
    private static PackedScene _floor = ResourceLoader.Load<PackedScene>("res://sprites/Floor.tscn");

    public override void _UnhandledInput(InputEvent @event)
    {
        if (@event.IsActionPressed(InputName.InitWorld))
        {
            InitFloor();
            InitPlayerCharacter();
            SetProcessUnhandledInput(false);
        }
    }

    private void InitFloor()
    {
        for(int x = 0; x < DungeonSize.MaxX; ++x)
        {
            for(int y = 0; y < DungeonSize.MaxY; ++y)
            {
                CreateSprite(_floor, GroupName.Floor, x, y);
            }
        }
    }

    private void InitPlayerCharacter()
    {
        CreateSprite(_player, GroupName.PlayerCharacter, 0, 0);
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
