using Godot;

public class MainScene : Node
{
    public override void _Ready()
    {
        GetNode("InitWorld").Connect(nameof(InitWorld.SpriteCreated), GetNode("PCMove"), nameof(PCMove._on_InitWorld_SpriteCreated));
    }
}
