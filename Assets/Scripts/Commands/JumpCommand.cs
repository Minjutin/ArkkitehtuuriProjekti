using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpCommand : Command
{
    public static event System.Action Jumped;

    public override void Execute()
    {
        //Only execute jumping if current state is jumping. If it is executed, make current state jumping.
        if(PlayerStateMachine.currentState == PlayerStateMachine.PlayerState.Standing)
        {
            GameManager.GM.player.RB.AddForce(Vector3.up * GameManager.GM.player.jumpSpeed);
            Jumped?.Invoke();
        }
    }

    public override void Undo()
    {
        throw new System.NotImplementedException();
    }
}
