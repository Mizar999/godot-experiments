using Godot;

public class MainGUI : Control
{
    private Label _label;

    public override void _Ready()
    {
        _label = GetNode<Label>("Label");
    }

    public void SetText(string text)
    {
        _label.Text = text;
    }
}
