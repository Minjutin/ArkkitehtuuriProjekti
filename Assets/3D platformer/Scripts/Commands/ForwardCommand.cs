using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForwardCommand : Command
{
    public override void Execute()
    {
        GameManager.GM.player.MovePlayerToDir(Vector3.forward);
    }

    public override void Undo()
    {
        GameManager.GM.player.MovePlayerToDir(-Vector3.forward);
    }
}
