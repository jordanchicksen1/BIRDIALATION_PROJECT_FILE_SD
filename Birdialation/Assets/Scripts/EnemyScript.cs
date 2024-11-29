using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyScript : MonoBehaviour
{
    public bool isInWorldOne=false;
    public bool isInWorldTwo=false;
    public bool isInWorldThree=false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Crate"))
        {
            Destroy(gameObject);
            SceneManager.LoadScene("Part01");

        }
        else if (collision.gameObject.CompareTag("Bullet") && isInWorldThree == false && isInWorldOne == false && isInWorldTwo == false)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("Part01");
        }
        else if (collision.gameObject.CompareTag("Bullet") && isInWorldOne == true && isInWorldThree == false && isInWorldTwo == false)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("Part02");
        }
        else if (collision.gameObject.CompareTag("Bullet") && isInWorldTwo == true && isInWorldThree == false && isInWorldOne == false)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("Part03");
        }
        else if (collision.gameObject.CompareTag("Bullet") && isInWorldThree == true && isInWorldOne == false && isInWorldTwo == false)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("MainMenu");
        }
        else if (collision.gameObject.CompareTag("BigRock"))
        {
            Destroy(gameObject);
            SceneManager.LoadScene("Part01");
        }
        else if (collision.gameObject.CompareTag("BigRock2"))
        {
            Destroy(gameObject);
            SceneManager.LoadScene("Part02");
        }
        else if (collision.gameObject.CompareTag("BigRock3"))
        {
            Destroy(gameObject);
            SceneManager.LoadScene("Part03");
        }


    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "World1")
        {
            isInWorldOne = true;
            isInWorldTwo = false;
            isInWorldThree = false;
        }
        if (other.tag == "World2")
        {
            isInWorldTwo = true;
            isInWorldThree = false;
            isInWorldOne = false;
        }
        if (other.tag == "World3")
        {
            isInWorldThree = true;
            isInWorldOne = false;
            isInWorldTwo = false;
        }
    }
}
