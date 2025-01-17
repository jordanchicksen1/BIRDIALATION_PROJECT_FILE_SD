using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimBuyManager : MonoBehaviour
{
    public List<GameObject> Locks;     // List of lock GameObjects
    public List<GameObject> Buttons;  // List of buttons associated with locks
    private bool[] unlockedItems;      // Tracks which items are unlocked
    [SerializeField]
    private GameObject weaponParent;

    [SerializeField]
    private List<GameObject> Weapons;
    public Transform SlingPosition;

    [SerializeField]
    private List<int> WeaponPrices;

    public SaveManager saveManager;
    private void Start()
    {
        LoadData();
        UpdateLocksAndButtons();

    }

    public void BuyItem(int index)
    {
        // Validate the index
        if (index < 1 || index > Locks.Count)
        {
            Debug.LogWarning("Invalid index: " + index);
            return;
        }

        int actualIndex = index - 1; // Convert 1-based index to 0-based

        // Check if already unlocked
        if (unlockedItems[actualIndex])
        {
            Debug.LogWarning("Item already unlocked!");
            return;
        }

        // Check if the player has enough coins
        if (saveManager.Coins < WeaponPrices[actualIndex])
        {
            Debug.LogWarning("Not enough coins!");
            return;
        }

        // Deduct the price and unlock the item
        saveManager.IncrementCoins(WeaponPrices[actualIndex]);
        UnlockItem(actualIndex);
        SaveData();
    }



    private void UnlockItem(int index)
    {
        if (Locks[index] != null)
        {
            Destroy(Locks[index]);
            Locks[index] = null; // Clear the reference
        }

        if (Buttons[index] != null)
        {
            Destroy(Buttons[index]);
            Buttons[index] = null; // Clear the reference
        }

        unlockedItems[index] = true; // Mark item as unlocked
        Debug.Log("Unlocked item and destroyed button at index: " + index);
    }

    private void UpdateLocksAndButtons()
    {
        for (int i = 0; i < Locks.Count; i++)
        {
            if (unlockedItems[i])
            {
                if (Locks[i] != null)
                {
                    Locks[i].SetActive(false);
                    Locks[i] = null; // Clear the reference
                }

                if (Buttons[i] != null)
                {
                    Buttons[i].SetActive(false);
                    Buttons[i] = null; // Clear the reference
                }
            }
        }
    }

    private void SaveData()
    {
        for (int i = 0; i < unlockedItems.Length; i++)
        {
            PlayerPrefs.SetInt($"UnlockedItem_{i}", unlockedItems[i] ? 1 : 0);
        }
        PlayerPrefs.Save();
        Debug.Log("Data Saved!");
    }

    private void LoadData()
    {
        unlockedItems = new bool[Locks.Count];
        for (int i = 0; i < unlockedItems.Length; i++)
        {
            unlockedItems[i] = PlayerPrefs.GetInt($"UnlockedItem_{i}", 0) == 1;
        }
        Debug.Log("Data Loaded!");
    }

    public void SelectItem(int i)
    {
        weaponParent = GameObject.FindGameObjectWithTag("WeaponParent");
        if (weaponParent.transform.childCount == 0)
        {

            if (i == 1)
            {
               GameObject Weapon = Instantiate(Weapons[0], SlingPosition.position, Quaternion.identity);
                Weapon.transform.parent = weaponParent.transform;
            }
            else if (i == 2)
            {
                GameObject Weapon = Instantiate(Weapons[1], SlingPosition.position, Quaternion.identity);
                Weapon.transform.parent = weaponParent.transform;

            }
            else if (i == 3)
            {
                
            }
            else if (i == 4)
            {

                GameObject Weapon = Instantiate(Weapons[3], SlingPosition.position, Quaternion.identity);
                Weapon.transform.parent = weaponParent.transform;
            }
            else if (i == 5)
            {
                GameObject Weapon = Instantiate(Weapons[4], SlingPosition.position, Quaternion.identity);
                Weapon.transform.parent = weaponParent.transform;

            }
            else if (i == 6)
            {

            }
        }
    }

    public void ResetData()
    {
        // Clear PlayerPrefs
        for (int i = 0; i < Locks.Count; i++)
        {
            PlayerPrefs.DeleteKey($"UnlockedItem_{i}");
        }

        // Reset internal data
        unlockedItems = new bool[Locks.Count];

        // Reactivate locks and buttons
        for (int i = 0; i < Locks.Count; i++)
        {
            if (Locks[i] == null)
            {
                
                Debug.LogWarning($"Lock {i + 1} is missing. Please ensure prefabs are set up.");
            }
            else
            {
                Locks[i].SetActive(true);
            }

            if (Buttons[i] == null)
            {
                
                Debug.LogWarning($"Button {i + 1} is missing. Please ensure prefabs are set up.");
            }
            else
            {
                Buttons[i].SetActive(true);
            }
        }

        PlayerPrefs.Save();
        LoadData();
        Debug.Log("Data Reset to Default State!");
    }
}
