using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public int Coins = 0;
    public GameObject coin;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Rock")
        {
            Destroy(coin);
            Coins++;
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
