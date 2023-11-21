using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Achievements : MonoBehaviour
{

    private const int achievementCount = 4;
    public enum Achievement
    {
        Coin_Collector,
        Muumipeikko_Murskain,
        Falling_To_Void,
        I_AM_GIGANTIOUS
    }

    private bool[] unlockedAchievements = new bool[achievementCount];

    private int coins = 0;
    private int killed = 0;



    void Start()
    {
        Coin.OnCoinCollected += CoinWasCollected;      //Add listener to event  
        Enemy.FellDown += MoominFellDown;
        Enemy.BrutallyMurdered += KilledMoomin;
        Player.SpecialStart += BeingGigantic;
    }

    void CoinWasCollected()
    {
       
        coins++;
        if(coins == 5)
        {
            int i = (int)Achievement.Coin_Collector;
            if (!unlockedAchievements[i])
            {
                unlockedAchievements[i] = true;
                Debug.Log("YOU HAVE UNLOCKED ACHIEVEMENT COIN COLLECTOR");
            }
        }
    }

    void KilledMoomin()
    {
        killed++;
        if(killed == 2)
        {
            int i = (int)Achievement.Muumipeikko_Murskain;
            if (!unlockedAchievements[i])
            {
                unlockedAchievements[i] = true;
                Debug.Log("YOU HAVE UNLOCKED ACHIEVEMENT MUUMIPEIKKO_MURSKAIN");
            }
        }
    }

    void MoominFellDown()
    {
        int i = (int)Achievement.Falling_To_Void;
        if (!unlockedAchievements[i])
        {
            unlockedAchievements[i] = true;
            Debug.Log("YOU HAVE UNLOCKED ACHIEVEMENT FALLING TO VOID");
        }
    }

    void BeingGigantic()
    {
        int i = (int)Achievement.I_AM_GIGANTIOUS;
        if (!unlockedAchievements[i])
        {
            unlockedAchievements[i] = true;
            Debug.Log("YOU HAVE UNLOCKED ACHIEVEMENT I AM HULK");
        }
    }

}
