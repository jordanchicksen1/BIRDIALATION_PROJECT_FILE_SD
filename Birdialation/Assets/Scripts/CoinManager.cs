using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour
{
    public int Coins = 0;
    public TextMeshProUGUI coinCount;

    public void AddCoin()
    {
        Coins++;
        UpdateCoinUI();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other)
        {
            Destroy(gameObject);
            Coins++;
            UpdateCoinUI();
        }
    }

    private void UpdateCoinUI()
    {
        coinCount.text = "Coins: " + Coins++;
        
    }
}