using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrouchCommand : Command
{
    public static event System.Action StartCrouch;
    public static event System.Action StopCrouch;

    public override void Execute()
    {
        //Start crouching
        if(PlayerStateMachine.currentState == PlayerStateMachine.PlayerState.Standing)
        {
            GameManager.GM.player.Crouch(true);
            StartCrouch?.Invoke();
        }

        //Stop crouching
        else if(PlayerStateMachine.currentState == PlayerStateMachine.PlayerState.Crouching)
        {
            GameManager.GM.player.Crouch(false);
            StopCrouch?.Invoke();
        }

    }

    public override void Undo()
    {
        throw new System.NotImplementedException();
    }
}
