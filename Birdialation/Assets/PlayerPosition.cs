using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPosition : MonoBehaviour
{
    private GameObject Player;

    private void Awake()
    {

        Player = GameObject.FindGameObjectWithTag("Player");
        Player.transform.position = transform.position;
    }
}
