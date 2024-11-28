using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private int hitCount;
    private void OnCollisionEnter2D(Collision2D collision )
    {
        if ( collision.gameObject.CompareTag("Enemy") )
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }else if (collision.gameObject.CompareTag("Platform") )
        {
            hitCount++;
            if (hitCount == 4)
            {
                Destroy(gameObject);
                hitCount = 0;
            }
        }else if (collision.gameObject.CompareTag("Crate"))
        {
            Destroy(gameObject);
        }
        


    }
}
