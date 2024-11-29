using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class StarCountManager : MonoBehaviour
{
    public int CurrentLevel1Stars, CurrentLevel2Stars, CurrentLevel3Stars, CurrentLevel4Stars, CurrentLevel5Stars, 
               CurrentLevel6Stars, CurrentLevel7Stars, CurrentLevel8Stars, CurrentLevel9Stars,
               CurrentLevel10Stars, CurrentLevel11Stars, CurrentLevel12Stars, CurrentLevel13Stars,
               CurrentLevel14Stars, CurrentLevel15Stars;

    public SaveManager savemanger;

    public void AddStars()
    {
        if (SceneManager.GetActiveScene().name == "BlockOutLevel1")
        {
            if (CurrentLevel10Stars > savemanger.saveData.Level1Stars)
            {
                savemanger.saveData.Level1Stars -= savemanger.saveData.Level1Stars;
                savemanger.saveData.Level1Stars += CurrentLevel10Stars;
            }
            else { return; }
        }
    }
}
