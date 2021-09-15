using Godot;

public class Board : TileMap
{
    public const int MaxX = 40;
    public const int MaxY = 15;
    public static readonly Vector2 TileSize = new Vector2(24, 36);

    private static PackedScene _player = ResourceLoader.Load<PackedScene>("res://objects/Player.tscn");
    private static PackedScene _target = ResourceLoader.Load<PackedScene>("res://objects/Target.tscn");
    private static PackedScene _box = ResourceLoader.Load<PackedScene>("res://objects/Box.tscn");

    private GameController _controller;

    public void Initialize(GameController controller)
    {
        _controller = controller;
    }

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

    public bool IsPassable(Vector2 coord)
    {
        return GetCell((int)coord.x, (int)coord.y) == 0;
    }

    private void InitFloor()
    {
        for (int x = 0; x < MaxX; ++x)
        {
            for (int y = 0; y < MaxY; ++y)
            {
                SetCell(x, y, 0);
            }
        }
    }

    private void InitPlayerCharacter()
    {
        CreatePlayer(0, 0);
    }

    private void InitTarget()
    {
        CreateTarget(3, 3);
        CreateTarget(3, Board.MaxY - 3);
    }

    private void InitBox()
    {
        CreateBox(3, 1);
        CreateBox(Board.MaxX - 5, 5);
        CreateBox(Board.MaxX - 5, Board.MaxY - 5);
    }

    private void CreatePlayer(int x, int y)
    {
        Player player = _player.Instance<Player>();
        player.Position = MapToWorld(new Vector2(x, y));
        player.AddToGroup(GroupName.PlayerCharacter);
        player.Initialize(this);
        AddChild(player);
    }

    private void CreateBox(int x, int y)
    {
        Box box = _box.Instance<Box>();
        box.Position = MapToWorld(new Vector2(x, y));
        box.AddToGroup(GroupName.Box);
        box.Initialize(this);
        AddChild(box);
    }

    private void CreateTarget(int x, int y)
    {
        Target target = _target.Instance<Target>();
        target.Position = MapToWorld(new Vector2(x, y));
        target.AddToGroup(GroupName.Target);
        target.Initialize(_controller);
        AddChild(target);
    }
}
