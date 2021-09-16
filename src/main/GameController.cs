using Godot;

public class GameController : Node
{
    private MainGUI _gui;
    private int _numberOfTargets;
    private int _targetsWithBox;

    public void Initialize(MainGUI gui)
    {
        _gui = gui;
    }

    public void OnLevelCreated(int numberOfTargets)
    {
        _numberOfTargets = numberOfTargets;
    }

    public void OnBoxEntered(Node body)
    {
        if (IsBox(body))
        {
            ++_targetsWithBox;
            if (_targetsWithBox == _numberOfTargets)
            {
                _gui.SetText("You win!");
            }
        }
    }

    public void OnBoxExited(Node body)
    {
        if (IsBox(body))
        {
            --_targetsWithBox;
        }
    }

    private bool IsBox(Node body)
    {
        Box box = body as Box;
        return box != null;
    }
}
