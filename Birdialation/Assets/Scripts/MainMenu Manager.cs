using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenuManager : MonoBehaviour
{
    public GameObject Part01Button;
    public GameObject Part02Button;
    public GameObject Part03Button;

    public GameObject Part01;
    public GameObject Part02;
    public GameObject Part03;

    public void Part01ButtonClicked()
    {
        SceneManager.LoadScene("Part01");
    }
    public void Next01()
    {
        Part01Button.SetActive(false);
        Part02Button.SetActive(true);
        Part01.SetActive(false);
        Part02.SetActive(true);
    }
    public void Part02ButtonClicked()
    {
        SceneManager.LoadScene("Part02");
    }
    public void Next02()
    {
        Part02Button.SetActive(false);
        Part03Button.SetActive(true);
        Part02.SetActive(false);
        Part03.SetActive(true);
    }
    public void Part03ButtonClickecd()
    {
        SceneManager.LoadScene("Part03");
    }
    public void Next03()
    {
        Part03Button.SetActive(false);
        Part01Button.SetActive(true);
        Part03.SetActive(false);
        Part01.SetActive(true);
    }

}
