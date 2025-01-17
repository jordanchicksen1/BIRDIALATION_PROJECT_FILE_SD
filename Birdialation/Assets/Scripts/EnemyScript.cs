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
    public CoinManager coinManager;
    public SaveManager saveManager;

    public int coinsCollected;

    [SerializeField]
    private GameObject Coin;

    [SerializeField]
    private GameObject saveManagerGameObject;

    private void Awake()
    {
        Coin = GameObject.FindGameObjectWithTag("Coin");
        saveManagerGameObject = GameObject.FindGameObjectWithTag("Data");

        coinManager = Coin.GetComponent<CoinManager>();
        saveManager = saveManagerGameObject.GetComponent<SaveManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Crate"))
        {
            GameObject weaponParent = new GameObject();
            weaponParent = GameObject.FindGameObjectWithTag("WeaponParent");
            foreach(Transform child in weaponParent.transform)
            {
                Destroy(child.gameObject);
            }

            saveManager.AddCoins(coinsCollected);
            saveManager.AddCoins(5);
            Destroy(gameObject);
            SceneManager.LoadScene("Part01");
        }
        else if (collision.gameObject.CompareTag("Bullet") && isInWorldThree == false && isInWorldOne == false && isInWorldTwo == false)
        {
            GameObject weaponParent = new GameObject();
            weaponParent = GameObject.FindGameObjectWithTag("WeaponParent");
            foreach (Transform child in weaponParent.transform)
            {
                Destroy(child.gameObject);
            }
            saveManager.AddCoins(coinsCollected);
            Destroy(gameObject);
            SceneManager.LoadScene("Part01");
        }
        else if (collision.gameObject.CompareTag("Bullet") && isInWorldOne == true && isInWorldThree == false && isInWorldTwo == false)
        {
            GameObject weaponParent = new GameObject();
            weaponParent = GameObject.FindGameObjectWithTag("WeaponParent");
            foreach (Transform child in weaponParent.transform)
            {
                Destroy(child.gameObject);
            }

            saveManager.AddCoins(coinsCollected);
            Destroy(gameObject);
            SceneManager.LoadScene("Part02");
        }
        else if (collision.gameObject.CompareTag("Bullet") && isInWorldTwo == true && isInWorldThree == false && isInWorldOne == false)
        {
            GameObject weaponParent = new GameObject();
            weaponParent = GameObject.FindGameObjectWithTag("WeaponParent");
            foreach (Transform child in weaponParent.transform)
            {
                Destroy(child.gameObject);
            }

            saveManager.AddCoins(coinsCollected);    
            Destroy(gameObject);
            SceneManager.LoadScene("Part03");
        }
        else if (collision.gameObject.CompareTag("Bullet") && isInWorldThree == true && isInWorldOne == false && isInWorldTwo == false)
        {
            GameObject weaponParent = new GameObject();
            weaponParent = GameObject.FindGameObjectWithTag("WeaponParent");
            foreach (Transform child in weaponParent.transform)
            {
                Destroy(child.gameObject);
            }

            saveManager.AddCoins(coinsCollected);
            Destroy(gameObject);
            SceneManager.LoadScene("MainMenu");
        }
        else if (collision.gameObject.CompareTag("BigRock"))
        {
            GameObject weaponParent = new GameObject();
            weaponParent = GameObject.FindGameObjectWithTag("WeaponParent");
            foreach (Transform child in weaponParent.transform)
            {
                Destroy(child.gameObject);
            }

            saveManager.AddCoins(coinsCollected);
            Destroy(gameObject);
            SceneManager.LoadScene("Part01");
        }
        else if (collision.gameObject.CompareTag("BigRock2"))
        {
            GameObject weaponParent = new GameObject();
            weaponParent = GameObject.FindGameObjectWithTag("WeaponParent");
            foreach (Transform child in weaponParent.transform)
            {
                Destroy(child.gameObject);
            }

            saveManager.AddCoins(coinsCollected);
            Destroy(gameObject);
            SceneManager.LoadScene("Part02");
        }
        else if (collision.gameObject.CompareTag("BigRock3"))
        {
            GameObject weaponParent = new GameObject();
            weaponParent = GameObject.FindGameObjectWithTag("WeaponParent");
            foreach (Transform child in weaponParent.transform)
            {
                Destroy(child.gameObject);
            }

            saveManager.AddCoins(coinsCollected);
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
