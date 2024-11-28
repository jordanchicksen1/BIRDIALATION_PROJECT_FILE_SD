using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rope : MonoBehaviour
{
    public Rigidbody2D rockRB;


    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            rockRB = GetComponent<Rigidbody2D>();
            rockRB.bodyType = RigidbodyType2D.Kinematic;
        }
    }
}
