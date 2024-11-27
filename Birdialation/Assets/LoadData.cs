using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    [System.Serializable]
    public class SaveData
    {
        public int coins;
        public int stars;

        [Header("Levels")]
        public bool Level1Unclocked;
        public bool Level2Unclocked;
        public bool Level3Unclocked;
        public bool Level4Unclocked;
        public bool Level5Unclocked;
        public bool Level6Unclocked;
        public bool Level7Unclocked;
        public bool Level8Unclocked;
        public bool Level9Unclocked;
        public bool Level10Unclocked;
        public bool Level11Unclocked;
        public bool Level12Unclocked;
        public bool Level13Unclocked;
        public bool Level14Unclocked;
        public bool Level15Unclocked;

        [Header("Weapons")]
        public bool weapon1Unlocked;
        public bool weapon2Unlocked;
        public bool weapon3Unlocked;
        public bool weapon4Unlocked;
        public bool weapon5Unlocked;
        public bool weapon6Unlocked;


    }

    public static SaveManager Instance { get; private set; } // Singleton instance

    private SaveData saveData = new SaveData();

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

    private void Start()
    {
        LoadGame();
    }

    public void UpdateCoins(int value)
    {
        saveData.coins = value;
        AutoSave();
    }

    public void UpdateStars(int value)
    {
        saveData.stars = value;
        AutoSave();
    }

    public void FixedUpdate()
    {
        AutoSave();
    }

    private void AutoSave()
    {
        SaveGame();
    }

    public void SaveGame()
    {
        string json = JsonUtility.ToJson(saveData);
        PlayerPrefs.SetString("SaveData", json);
        PlayerPrefs.Save();
        Debug.Log("Game Saved!");
    }

    public void LoadGame()
    {
        if (PlayerPrefs.HasKey("SaveData"))
        {
            string json = PlayerPrefs.GetString("SaveData");
            try
            {
                saveData = JsonUtility.FromJson<SaveData>(json);
                Debug.Log("Game Loaded!");
            }
            catch
            {
                Debug.LogWarning("Failed to load save data. Starting fresh.");
                saveData = new SaveData();
            }
        }
        else
        {
            Debug.Log("No save data found. Starting fresh.");
        }
    }

    public void ResetGameData()
    {
        PlayerPrefs.DeleteKey("SaveData");
        saveData = new SaveData();
        Debug.Log("Game data reset.");
    }
}