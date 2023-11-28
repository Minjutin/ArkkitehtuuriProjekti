using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    readonly Command cmd_fwd = new ForwardCommand();
    readonly Command cmd_left = new LeftCommand();
    readonly Command cmd_back = new BackCommand();
    readonly Command cmd_right = new RightCommand();
    readonly Command cmd_jump = new JumpCommand();
    readonly Command cmd_crouch = new CrouchCommand();
   

    Stack<Command> previous_commands = new();
    Stack<Command> deleted_commands = new();

    private void Update()
    {
        //MOVE
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            cmd_fwd.Execute();
            previous_commands.Push(cmd_fwd);
        }

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            cmd_left.Execute();
            previous_commands.Push(cmd_left);
        }

        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            cmd_back.Execute();
            previous_commands.Push(cmd_back);
        }

        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            cmd_right.Execute();
            previous_commands.Push(cmd_right);
        }


        // ------------------ UNDO THINGS

        //UNDO MOVEMENT
        if (Input.GetKeyDown(KeyCode.Z))
        {
            UndoLastMovement();
        }
        //UNDO UNDOED MOVEMENT
        else if (Input.GetKeyDown(KeyCode.Y))
        {
            if(deleted_commands.Count > 0)
            {
                Command taken = deleted_commands.Pop();
                taken.Execute();
                previous_commands.Push(taken);
            }
        }
        else if (Input.anyKeyDown)//If no Z or Y, clear previous deleted commands stack
        {
            deleted_commands.Clear();
        }

        // ------------------ Do stuff

        //JUMP
        if (Input.GetKeyDown(KeyCode.Space))
        {
            cmd_jump.Execute();
        }


        //Crouch
        if (Input.GetKeyDown(KeyCode.C))
        {
            cmd_crouch.Execute();
        }


    }

    public void UndoLastMovement() {
        if (previous_commands.Count > 0)
        {
            Command taken = previous_commands.Pop();
            taken.Undo();
            deleted_commands.Push(taken);
        }
    }
}
