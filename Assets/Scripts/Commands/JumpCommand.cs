using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpCommand : Command
{
    public override void Execute()
    {
        GameManager.GM.player.RB.AddForce(Vector3.up * GameManager.GM.player.jumpSpeed);
    }

    public override void Undo()
    {
        throw new System.NotImplementedException();
    }
}
