using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class throwScript : MonoBehaviour
{
    public GameObject Rock;
    public Transform Player;

    public void Throw()
    {
        Rigidbody2D rb;
        GameObject Rocks = Instantiate(Rock, Player.position, Quaternion.identity);
        rb = Rocks.GetComponent<Rigidbody2D>();
        rb.velocity = Vector3.up;

    }
}
