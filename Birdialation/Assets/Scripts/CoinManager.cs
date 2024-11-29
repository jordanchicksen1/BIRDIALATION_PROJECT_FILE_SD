
using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour
{
    public int Coins = 0;
    public TextMeshProUGUI coinCount;

    public SaveManager saveManager;
    private GameObject Data;
    public GameObject TextObject;

    private void Awake()
    {
        TextObject = GameObject.FindGameObjectWithTag("TextObject");
        coinCount = TextObject.GetComponent<TextMeshProUGUI>();

        Data = GameObject.FindGameObjectWithTag("Data");
       saveManager = Data.GetComponent<SaveManager>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other)
        {
            saveManager.saveData.coins++;
            UpdateCoinUI();
            saveManager.SaveGame();
            Destroy(gameObject);
        }
    }

    private void UpdateCoinUI()
    {
        coinCount.text = "" + saveManager.saveData.coins;
        
    }

    public void Update()
    {
        UpdateCoinUI();
    }
}