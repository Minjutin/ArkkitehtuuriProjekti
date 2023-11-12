using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    readonly Command cmd_w = new ForwardCommand();
    readonly Command cmd_a = new LeftCommand();
    readonly Command cmd_s = new BackCommand();
    readonly Command cmd_d = new RightCommand();
    readonly Command cmd_space = new JumpCommand();
   

    Stack<Command> previous_commands = new();
    Stack<Command> deleted_commands = new();

    private void Update()
    {
        //MOVE
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            cmd_w.Execute();
            previous_commands.Push(cmd_w);
        }

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            cmd_a.Execute();
            previous_commands.Push(cmd_a);
        }

        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            cmd_s.Execute();
            previous_commands.Push(cmd_s);
        }

        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            cmd_d.Execute();
            previous_commands.Push(cmd_d);
        }

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


        //JUMP
        if (Input.GetKeyDown(KeyCode.Space))
        {
            cmd_space.Execute();
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
