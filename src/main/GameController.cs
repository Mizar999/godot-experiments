using Godot;
using System;

public class GameController : Node
{
    public void OnBoxEntered(Node body)
    {
        GD.Print(string.Format("Entered: {0}", body.Name));
    }

    public void OnBoxExited(Node body)
    {
        GD.Print(string.Format("Exited: {0}", body.Name));
    }
}
