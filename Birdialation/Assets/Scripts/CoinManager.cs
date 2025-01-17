
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

    public GameObject Particles;

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
            enemyScrpt.coinsCollected += 5;
            
            UpdateCoinUI();
            GameObject Particle = Instantiate(Particles, transform.position, Quaternion.identity);
            Destroy(Particle, 1);
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