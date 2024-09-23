using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsTab : MonoBehaviour
{
    public GameObject Weapons;
    public GameObject[] usableWeapons;


    private void Start()
    {
        Weapons.SetActive(false);
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
