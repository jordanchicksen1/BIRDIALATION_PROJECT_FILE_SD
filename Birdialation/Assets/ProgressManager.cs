using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int totalCoins;
    public int totalStars;

    public bool[] levelUnlocked;
    public bool[] weaponsUnlocked;
    
    public GameData()
    {
        totalCoins = 0;
        totalStars = 0;
        levelUnlocked = new bool[5];
        levelUnlocked[0] = true;
        weaponsUnlocked = new bool[5];
        weaponsUnlocked[0] = true;
    }
}
