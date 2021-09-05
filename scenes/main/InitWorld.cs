using Godot;
using System;

public class InitWorld : Node
{
    private static PackedScene _player = ResourceLoader.Load<PackedScene>("res://sprites/PC.tscn");
    private static PackedScene _floor = ResourceLoader.Load<PackedScene>("res://sprites/Floor.tscn");

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        createSprite(_player, GroupName.PLAYER_CHARACTER, 0, 0);
        
        for(int x = 0; x < DungeonSize.MAX_X; ++x)
        {
            for(int y = 0; y < DungeonSize.MAX_Y; ++y)
            {
                createSprite(_floor, GroupName.FLOOR, x, y);
            }
        }
    }

    private void createSprite(PackedScene prefab, string group, int x, int y, int offsetX = 0, int offsetY = 0)
    {
        Sprite newSprite = prefab.Instance<Sprite>();
        newSprite.Position = ConvertCoordinate.indexToVector(x, y, offsetX, offsetY);
        newSprite.AddToGroup(group);
        AddChild(newSprite);
    }
}
