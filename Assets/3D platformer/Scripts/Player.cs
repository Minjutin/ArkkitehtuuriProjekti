using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static event System.Action PlayerMoved;
    public static event System.Action PlayerGrounded;
    public static event System.Action SpecialStart;
    public static event System.Action SpecialCanceled;

    public Rigidbody RB;
    public float speed = 2;
    public float jumpSpeed = 10;

    // Start is called before the first frame update
    void Awake()
    {
        RB = this.GetComponent<Rigidbody>();
    }

    //Update player data
    
    //Move player
    public void MovePlayerToDir(Vector3 dir)
    {
        //Trigger player has moved
        PlayerMoved?.Invoke();
        this.transform.position += speed * dir;
    }

    //What happens when player touches stuff like enemies, coins or ground?
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

        if (other.gameObject.GetComponent<SpecialPower>())
        {
            other.gameObject.SetActive(false);
            StartCoroutine(SpecialGrow());
        }
    }

    public void OnCollisionEnter(Collision other)
    {
        //If colliding with ground
        if(other.gameObject.layer == 6)
        {
            PlayerGrounded?.Invoke();
        }
    }


    //Crouch
    public void Crouch(bool crouch)
    {
        //If player should crouch
        if (crouch)
        {
            transform.localScale = new Vector3(1f, 0.5f, 1f);
        }
        else
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }

    //Special power IENUMERATOR
    //You are now big for 10 seconds
    IEnumerator SpecialGrow()
    {
        SpecialStart?.Invoke();
        transform.localScale = new Vector3(5f, 5f, 5f);
        this.transform.GetChild(0).GetComponent<MeshRenderer>().material.color = new Color32(8, 212, 0,255);

        for (int i = 0; i < 7; i++)
        {
            yield return new WaitForSeconds(1f);
        }
        transform.localScale = new Vector3(1f, 1f, 1f);
        SpecialCanceled?.Invoke();
    }
}
