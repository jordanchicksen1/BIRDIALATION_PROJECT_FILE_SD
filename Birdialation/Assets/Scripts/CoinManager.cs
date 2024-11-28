using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public int Coins = 0;
    public GameObject coin;

   
 
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other)
        {
            Destroy(gameObject);
            Coins++;
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
