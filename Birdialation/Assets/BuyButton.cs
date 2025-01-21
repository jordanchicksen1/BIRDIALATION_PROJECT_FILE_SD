using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyButton : MonoBehaviour
{
    [SerializeField]
    private int item = 1;

    [SerializeField]
    private int Level;

    [SerializeField]
    private int Price;

    [SerializeField]
    private TimBuyManager buyManager;

    [SerializeField]
    private LevelBuyManager levelBuyManager;

    public void OnBuyClick()
    {
        buyManager.BuyItem(item);
    }

    

    public void OnSelectClick()
    {
        buyManager.SelectItem(item);

    }

    public void OnClickUnlockLevel()
    {
        levelBuyManager.UnlockLevel(Level);
    }
}
