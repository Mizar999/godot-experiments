using Godot;

public class Target : Area2D
{
    private GameController _controller;

    public override void _Ready()
    {
        base.Connect("body_entered", _controller, nameof(GameController.OnBoxEntered));
        base.Connect("body_exited", _controller, nameof(GameController.OnBoxExited));
    }

    public void Initialize(GameController controller)
    {
        _controller = controller;
    }
}
