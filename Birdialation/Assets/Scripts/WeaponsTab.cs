using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsTab : MonoBehaviour
{
    public GameObject Weapons;
    public GameObject[] usableWeapons;

    public static WeaponsTab Instance { get; private set; } // Singleton instance
    private void Start()
    {
        Weapons.SetActive(false);
    }

    private void Awake()
    {
        // Singleton pattern to ensure only one instance of SaveManager exists
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject); // Persist across scenes
    }
    public void ShowWeapon()
    {
        Weapons .SetActive(true);   
    }

    public void HideWeapon()
    {
        Weapons.SetActive(false);
    }


}
