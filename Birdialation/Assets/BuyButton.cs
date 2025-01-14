using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyButton : MonoBehaviour
{
    [SerializeField]
    private int item = 1;

    [SerializeField]
    private TimBuyManager buyManager;

    public void OnBuyClick()
    {
        buyManager.BuyItem(item);
    }

    public void OnSelectClick()
    {
        buyManager.SelectItem(item);

    }
}
