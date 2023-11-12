using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager GM;

    public Player player;

    void Awake()
    {
        GM = this;
        player = FindObjectOfType<Player>();
    }


}
