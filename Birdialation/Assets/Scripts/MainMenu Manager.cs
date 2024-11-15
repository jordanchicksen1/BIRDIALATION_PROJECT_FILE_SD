using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenuManager : MonoBehaviour
{
   
    public void Part01ButtonClicked()
    {
        SceneManager.LoadScene("Part01");
    }
    public void Part02ButtonClicked()
    {
        SceneManager.LoadScene("Part02");
    }
    public void Part03ButtonClickecd()
    {
        SceneManager.LoadScene("Part03");
    }

}
