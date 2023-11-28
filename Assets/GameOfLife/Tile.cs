using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public bool alive = false;
    public bool nextAlive = false;


    public void CheckNextStatus(bool living)
    {
        nextAlive = living;
    }

    public void SetAlive(bool living)
    {
        alive = living;

        switch (living)
        {
            case true:
                this.GetComponent<MeshRenderer>().material.color = Color.red;
                break;
            case false:
                this.GetComponent<MeshRenderer>().material.color = Color.black;
                break;
        }
    }
}
