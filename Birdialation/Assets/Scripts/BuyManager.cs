using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Collections.AllocatorManager;

public class BuyManager : MonoBehaviour
{

    public GameObject Weapon1, Weapon2, Weapon3, Weapon4, Weapon5, Weapon6;
    public GameObject Lock1, Lock2, Lock3, Lock4, Lock5, Lock6;

    [Header("Weapon Choices")]
    public GameObject Sling, Cannon, Sniper, Bazooka;
    public Transform WeaponPosition;

    [Header("Script Reference")]
    public TimBuyManager TimBuyManager;

    private void Start()
    {
        // Load weapons based on save data
        if (SaveManager.Instance != null)
        {
            if (SaveManager.Instance.saveData.weapon1Unlocked) Weapon1.SetActive(true);
            if (SaveManager.Instance.saveData.weapon2Unlocked) Weapon4.SetActive(true);
            if (SaveManager.Instance.saveData.weapon3Unlocked) Weapon2.SetActive(true);
            if (SaveManager.Instance.saveData.weapon4Unlocked) Weapon5.SetActive(true);
            if (SaveManager.Instance.saveData.weapon5Unlocked) Weapon3.SetActive(true);
            if (SaveManager.Instance.saveData.weapon6Unlocked) Weapon6.SetActive(true);

            if (SaveManager.Instance.saveData.weapon1Unlocked) Lock1.SetActive(false);
            if (SaveManager.Instance.saveData.weapon2Unlocked) Lock2.SetActive(false)   ;
            if (SaveManager.Instance.saveData.weapon3Unlocked) Lock3.SetActive(false);
            if (SaveManager.Instance.saveData.weapon4Unlocked) Lock4.SetActive(false);
            if (SaveManager.Instance.saveData.weapon5Unlocked) Lock5.SetActive(false);
            if (SaveManager.Instance.saveData.weapon6Unlocked) Lock6.SetActive(false);
        }
        else
        {
            Debug.LogError("SaveManager instance not found!");
        }

        
    }   
}
