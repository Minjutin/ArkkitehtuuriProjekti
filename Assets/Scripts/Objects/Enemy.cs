using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static event System.Action FellDown;
    public static event System.Action BrutallyMurdered;

    public int hp = 2;

    private void Start()
    {
        Player.PlayerMoved += MoveEnemy;
    }

    private void Update()
    {
        if(this.transform.position.y < -30)
        {
            FellDown?.Invoke();
            Destroy(this.gameObject);
        }
    }

    public void OnDisable()
    {
        if(hp < 1)
        {
            Player.PlayerMoved -= MoveEnemy; 
            BrutallyMurdered?.Invoke();
        }

    }

    public void OnDestroy()
    {
        Player.PlayerMoved -= MoveEnemy;
    }

    public void MoveEnemy()
    {
        this.transform.position += Random.Range(-1,2)*Vector3.forward + Random.Range(-1,2)*Vector3.right;
    }
}
