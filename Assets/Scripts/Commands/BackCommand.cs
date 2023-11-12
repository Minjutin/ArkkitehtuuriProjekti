using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackCommand : Command
{
    public override void Execute()
    {
        GameManager.GM.player.MovePlayerToDir(Vector3.back);
    }

    public override void Undo()
    {
        GameManager.GM.player.MovePlayerToDir(-Vector3.back);
    }
}