using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static event System.Action playerMoved;

    public Rigidbody RB;
    public float speed = 2;
    public float jumpSpeed = 10;

    // Start is called before the first frame update
    void Awake()
    {
        RB = this.GetComponent<Rigidbody>();
    }

    public void MovePlayerToDir(Vector3 dir)
    {
        //Trigger player has moved
        playerMoved?.Invoke();
        this.transform.position += speed * dir;
    }

    public void OnTriggerEnter(Collider other)
    {
        //If trigger is coink
        if (other.GetComponent<Coin>())
        {
            other.gameObject.SetActive(false);
        }

        //If trigger is enemy
        if (other.gameObject.GetComponent<Enemy>())
        {
            other.gameObject.GetComponent<Enemy>().hp--;
            if (other.gameObject.GetComponent<Enemy>().hp < 1)
            {
                other.gameObject.SetActive(false);
            }
        }
    }


}
