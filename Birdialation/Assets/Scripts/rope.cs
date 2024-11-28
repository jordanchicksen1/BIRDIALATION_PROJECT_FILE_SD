using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rope : MonoBehaviour
{
    public GameObject rock;


    private void OnCollisionEnter2D(Collision2D collision)
    {
         if (collision.gameObject.CompareTag("Bullet"))
        {

           // rockRB = GetComponent<Rigidbody2D>();
           // rockRB.bodyType = RigidbodyType2D.Dynamic;
           rock.AddComponent<Rigidbody2D>();
            Destroy(gameObject, 2f);
           

            
        }
    }
}
