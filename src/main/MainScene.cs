using Godot;

public class MainScene : Node
{
    public override void _Ready()
    {
        (GetNode(nameof(Board)) as Board).Initialize(GetNode(nameof(GameController)) as GameController);
    }
}
