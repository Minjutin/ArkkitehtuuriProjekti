using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightCommand : Command
{
    public override void Execute()
    {
        GameManager.GM.player.MovePlayerToDir(Vector3.right);
    }

    public override void Undo()
    {
        GameManager.GM.player.MovePlayerToDir(-Vector3.right);
    }
}
