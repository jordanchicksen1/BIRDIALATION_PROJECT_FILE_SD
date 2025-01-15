using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public int Coins; // Tracks the player's current coin count

    private const string CoinsKey = "Coins"; // Key for saving/loading coins in PlayerPrefs

    private void Start()
    {
        LoadCoins(); // Load coins when the game starts
    }

    // Adds coins to the total and saves the data.
    /// <param name="amount">Amount of coins to add.</param>
    public void AddCoins(int amount)
    {
        Coins += amount;
        SaveCoins();
        Debug.Log($"Added {amount} coins. Total: {Coins}");
    }

    /// Spends coins and saves the data, if sufficient coins are available.
    /// </summary>
    /// <param name="amount">Amount of coins to spend.</param>
    /// <returns>True if the coins were spent, false otherwise.</returns>
    public bool SpendCoins(int amount)
    {
        if (Coins >= amount)
        {
            Coins -= amount;
            SaveCoins();
            Debug.Log($"Spent {amount} coins. Remaining: {Coins}");
            return true;
        }

        Debug.LogWarning("Not enough coins to spend!");
        return false;
    }

    /// <summary>
    /// Gets the current coin count.
    /// </summary>
    /// <returns>The current coin count.</returns>
    public int GetCoins()
    {
        return Coins;
    }

    /// <summary>
    /// Resets the coin data to zero and saves it.
    /// </summary>
    public void ResetCoins()
    {
        Coins = 0;
        SaveCoins();
        Debug.Log("Coins reset to zero.");
    }

    /// <summary>
    /// Saves the current coin count to PlayerPrefs.
    /// </summary>
    private void SaveCoins()
    {
        PlayerPrefs.SetInt(CoinsKey, Coins);
        PlayerPrefs.Save();
        Debug.Log("Coin data saved.");
    }

    /// <summary>
    /// Loads the coin count from PlayerPrefs.
    /// </summary>
    private void LoadCoins()
    {
        Coins = PlayerPrefs.GetInt(CoinsKey, 0);
        Debug.Log($"Coin data loaded. Total: {Coins}");
    }
}
