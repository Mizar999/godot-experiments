using Godot;

public class MainScene : Node
{
    public override void _Ready()
    {
        Board board = GetNode<Board>(nameof(Board));
        MainGUI gui = GetNode<MainGUI>(nameof(MainGUI));
        GameController gameController = GetNode<GameController>(nameof(GameController));

        gameController.Initialize(gui);

        board.Initialize(gameController, gui);
        board.Connect(nameof(Board.LevelCreated), gameController, nameof(GameController.OnLevelCreated));

        gui.SetText(MessageController.StartMessage);
    }
}
