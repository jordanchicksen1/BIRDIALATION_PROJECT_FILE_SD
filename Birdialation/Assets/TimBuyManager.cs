using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimBuyManager : MonoBehaviour
{
    [SerializeField]
    private List<BuyItem> items = new List<BuyItem>();

    public void BuyItem(int i)
    {

    }
}

[Serializable]
public class BuyItem
{
    public string Name;
    public int Damage;
    public string Effect;
}
