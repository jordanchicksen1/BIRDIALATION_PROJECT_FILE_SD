using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rope : MonoBehaviour
{
    public Rigidbody2D rockRB;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            rockRB = GetComponent<Rigidbody2D>();
            rockRB.bodyType = RigidbodyType2D.Kinematic;
        }
    }
}
