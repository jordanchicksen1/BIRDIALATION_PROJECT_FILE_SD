
using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour
{
    public TextMeshProUGUI coinCount;

    public SaveManager saveManager;
    private GameObject Data;
    public GameObject TextObject;

    public EnemyScript enemyScrpt;
    private GameObject Enemy;

    private void Awake()
    {
        TextObject = GameObject.FindGameObjectWithTag("TextObject");
        coinCount = TextObject.GetComponent<TextMeshProUGUI>();

        Data = GameObject.FindGameObjectWithTag("Data");
        saveManager = Data.GetComponent<SaveManager>();

        Enemy = GameObject.FindGameObjectWithTag("Enemy");
        enemyScrpt = Enemy.GetComponent<EnemyScript>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other)
        {
            enemyScrpt.coinsCollected++;
            
            UpdateCoinUI();
            Destroy(gameObject);
        }
    }

    private void UpdateCoinUI()
    {
        coinCount.text = "" + saveManager.Coins;
        
    }

    public void Update()
    {
        UpdateCoinUI();
    }
}