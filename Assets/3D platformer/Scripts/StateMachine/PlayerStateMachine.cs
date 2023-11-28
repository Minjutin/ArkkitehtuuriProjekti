using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerStateMachine
{
    public enum PlayerState { Standing, Jumping, Crouching, Special};

    public static PlayerState currentState = PlayerState.Standing;

    public static void InitializeStates()
    {
        //From JUMPING to STANDING
        Player.PlayerGrounded += ChangeToStanding;

        //From STANDING to JUMPING
        JumpCommand.Jumped += ChangeToJumping;

        //From STANDING to CROUCHING
        CrouchCommand.StartCrouch += ChangeToCrouching;

        //From CROUCHING to STANDING
        CrouchCommand.StopCrouch += ChangeToStanding;

        //From ANY STATE to SPECIAL
        Player.SpecialStart += ChangeToSpecial;

        //From SPECIAL to STANDING
        Player.SpecialCanceled += ChangeToStanding;
    }

    public static void ChangeToStanding()
    {
        currentState = PlayerState.Standing;
    }

    public static void ChangeToJumping()
    {
        currentState = PlayerState.Jumping;
    }

    public static void ChangeToCrouching()
    {
        currentState = PlayerState.Crouching;
    }

    public static void ChangeToSpecial()
    {
        currentState = PlayerState.Special;
    }
}
