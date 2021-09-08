using Godot;

public class MainScene : Node
{
    public override void _Ready()
    {
        GetNode("Board").Connect(nameof(Board.SpriteCreated), GetNode("PCMove"), nameof(PCMove._on_InitWorld_SpriteCreated));
        (GetNode("PCMove") as PCMove).Initialize(GetNode("Board") as Board);
    }
}
