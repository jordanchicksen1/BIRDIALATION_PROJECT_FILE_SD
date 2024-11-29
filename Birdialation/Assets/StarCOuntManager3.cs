using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class StarCountManager3 : MonoBehaviour
{
    public SaveManager saveManager;
    public TextMeshProUGUI StarsUI;

    public int CurrentLevel1Stars, CurrentLevel2Stars, CurrentLevel3Stars, CurrentLevel4Stars, CurrentLevel5Stars,
               CurrentLevel6Stars, CurrentLevel7Stars, CurrentLevel8Stars, CurrentLevel9Stars,
               CurrentLevel10Stars, CurrentLevel11Stars, CurrentLevel12Stars, CurrentLevel13Stars,
               CurrentLevel14Stars, CurrentLevel15Stars;


    public void AddStars()
    {
        if (SceneManager.GetActiveScene().name == "BlockOutLevel1")
        {
            Debug.Log("Love");

            if (CurrentLevel10Stars > saveManager.saveData.Level1Stars)
            {
                Debug.Log("Love");
                Debug.Log(saveManager.saveData.Level1Stars);
                saveManager.saveData.Level1Stars -= saveManager.saveData.Level1Stars;
                saveManager.saveData.Level1Stars++;
                
                saveManager.SaveGame();
                UpdateCoins();
            }
            else { return; }
        }
    }

    public void UpdateCoins()
    {
       StarsUI.text = "" + saveManager.saveData.stars;
    }

    void Update()
    {
        int TotalStars = saveManager.saveData.Level1Stars + saveManager.saveData.Level2Stars + saveManager.saveData.Level3Stars + saveManager.saveData.Level4Stars +
            saveManager.saveData.Level5Stars + saveManager.saveData.Level6Stars + saveManager.saveData.Level7Stars + saveManager.saveData.Level8Stars
            + saveManager.saveData.Level9Stars + saveManager.saveData.Level10Stars + saveManager.saveData.Level11Stars +
            saveManager.saveData.Level12Stars + saveManager.saveData.Level13Stars + saveManager.saveData.Level14Stars + saveManager.saveData.Level15Stars;


        saveManager.saveData.stars -= saveManager.saveData.stars;
            
    }
}
