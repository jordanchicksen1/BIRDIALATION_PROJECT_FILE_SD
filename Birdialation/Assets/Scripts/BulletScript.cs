using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private int hitCount;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Void") || collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }else if (collision.gameObject.CompareTag("Platform"))
        {
            hitCount++;
            if (hitCount == 4)
            {
                Destroy(gameObject);
                hitCount = 0;
            }
        }

    }
}
