using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager1 : MonoBehaviour
{
    public GameObject Weapons;

    public void ShowWeapons()
    {
        Weapons.SetActive(true);
    }

    public void HideWeapons()
    {
        Weapons.SetActive(false);
    }
}
