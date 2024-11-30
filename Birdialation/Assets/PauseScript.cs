using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    public List <String>  GrassyLevels;
    public List<String> RockyLevels;
    public List<String> SnowLevels;

    public GameObject GrassyLevelRestart;
    public GameObject SnowLevelRestart;
    public GameObject RockyLevelRestart;

    public GameObject PausePanel;


    private void Start()
    {
        GrassyLevels.Add("BlockOutLevel1");
        GrassyLevels.Add("BlockOutLevel2");
        GrassyLevels.Add("BlockOutLevel3");
        GrassyLevels.Add("BlockOutLevel4");
        GrassyLevels.Add("BlockOutLevel5");

        RockyLevels.Add("BlockOutLevel6");
        RockyLevels.Add("BlockOutLevel7");
        RockyLevels.Add("BlockOutLevel8");
        RockyLevels.Add("BlockOutLevel9");
        RockyLevels.Add("BlockOutLevel10");

        SnowLevels.Add("BlockOutLevel11");
        SnowLevels.Add("BlockOutLevel12");
        SnowLevels.Add("BlockOutLevel13");
        SnowLevels.Add("BlockOutLevel14");
        SnowLevels.Add("BlockOutLevel15");

        
    }

   
    public void RestartLevels()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string Scene = currentScene.name;
        SceneManager.LoadScene(Scene);

        PausePanel.SetActive(false);

    }


    

 

    
}
