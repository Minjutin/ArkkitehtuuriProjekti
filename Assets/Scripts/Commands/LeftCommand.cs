using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftCommand : Command
{
    public override void Execute()
    {
        GameManager.GM.player.MovePlayerToDir(Vector3.left);
    }

    public override void Undo()
    {
        GameManager.GM.player.MovePlayerToDir(Vector3.right);
    }
}