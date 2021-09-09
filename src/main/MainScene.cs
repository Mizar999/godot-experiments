using Godot;

public class MainScene : Node
{
    public override void _Ready()
    {
        GetNode("Board").Connect(nameof(Board.PlayerCreated), GetNode("PCMove"), nameof(PCMove.OnPlayerCreated));
        (GetNode("PCMove") as PCMove).Initialize(GetNode("Board") as Board);
    }
}
