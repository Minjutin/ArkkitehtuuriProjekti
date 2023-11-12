using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Coin : MonoBehaviour
{
    public static event Action OnCoinCollected;

    //Call event
    private void OnDisable()
    {
        OnCoinCollected?.Invoke();
    }

}
