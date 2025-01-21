using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockButton : MonoBehaviour
{
    

    [SerializeField]
    private int Level;

    [SerializeField]
    private LevelBuyManager levelBuyManager;

    public void OnClickUnlockLevel()
    {
        levelBuyManager.UnlockLevel(Level);
    }
}
