using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Collections.AllocatorManager;

public class BuyManager : MonoBehaviour
{
    public LayerMask mask;
    public LayerMask WeaponsLayer;
    public GameObject Weapon1, Weapon2, Weapon3, Weapon4, Weapon5, Weapon6;
    public GameObject Lock1, Lock2, Lock3, Lock4, Lock5, Lock6;
    public GameObject HeldObject;

    [SerializeField]
    private int Offset = 2;

    [Header("Weapon Choices")]
    public GameObject Sling, Cannon, Sniper, Bazooka;
    public Transform WeaponPosition;

    [Header("Rock Weapon Objects")]
    public GameObject Controller;
    public GameObject throwButton;

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

    public void Buy()
    {
        Vector2 Origin = transform.position;
        RaycastHit2D hit = Physics2D.Raycast(Origin, Vector3.up * Offset, mask);

        if (hit.collider != null)
        {
            GameObject Lock = hit.collider.gameObject;

            // Unlock the appropriate weapon based on the lock's name
            switch (Lock.name)
            {
                case "Weapon 1 Lock":
                    UnlockWeapon(Weapon1, "weapon1Unlocked", Lock);
                    break;
                case "Weapon 2 Lock":
                    UnlockWeapon(Weapon4, "weapon2Unlocked", Lock);
                    break;
                case "Weapon 3 Lock":
                    UnlockWeapon(Weapon2, "weapon3Unlocked", Lock);
                    break;
                case "Weapon 4 Lock":
                    UnlockWeapon(Weapon5, "weapon4Unlocked", Lock);
                    break;
                case "Weapon 5 Lock":
                    UnlockWeapon(Weapon3, "weapon5Unlocked", Lock);
                    break;
                case "Weapon 6 Lock":
                    UnlockWeapon(Weapon6, "weapon6Unlocked", Lock);
                    break;
                default:
                    Debug.LogWarning("Unknown lock name: " + Lock.name);
                    break;
            }
        }
    }

    private void UnlockWeapon(GameObject weapon, string saveKey, GameObject lockObject)
    {
        lockObject.SetActive(false);
        weapon.SetActive(true);
        Destroy(gameObject);

        // Update save data and save the game
        if (SaveManager.Instance != null)
        {
            SaveManager.Instance.saveData.GetType().GetField(saveKey).SetValue(SaveManager.Instance.saveData, true);
            SaveManager.Instance.SaveGame();
        }
        else
        {
            Debug.LogError("SaveManager instance not found!");
        }
    }

    public void UseWeapon()
    {
        Vector2 Origin = transform.position;
        RaycastHit2D hit = Physics2D.Raycast(Origin, Vector3.up * Offset, WeaponsLayer);

        if (hit.collider != null)
        {
            GameObject Weapon = hit.collider.gameObject;

            // Instantiate the selected weapon
            switch (Weapon.name)
            {
                case "Sling":
                    Instantiate(Sling, WeaponPosition.position, Quaternion.identity);
                    break;
                case "Sniper":
                    Instantiate(Sniper, WeaponPosition.position, Quaternion.identity);
                    break;
                case "Bazooka":
                    Instantiate(Bazooka, WeaponPosition.position, Quaternion.identity);
                    break;
                case "Cannon":
                    Instantiate(Cannon, WeaponPosition.position, Quaternion.identity);
                    break;
                default:
                    Debug.LogWarning("Unknown weapon name: " + Weapon.name);
                    break;
            }
        }
    }
}
