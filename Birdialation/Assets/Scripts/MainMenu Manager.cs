using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenuManager : MonoBehaviour
{
    public GameObject Part01;
    public GameObject Part02;
    public GameObject Part03;

    public void Part01ButtonClicked()
    {
        SceneManager.LoadScene("Part01");
    }
    public void Next01()
    {
        Part01.SetActive(false);
        Part02.SetActive(true);
    }
    public void Next04()
    {
        Part01.SetActive(false);
        Part03.SetActive(true);
    }
    public void Part02ButtonClicked()
    {
        SceneManager.LoadScene("Part02");
    }
    public void Next02()
    {
        Part02.SetActive(false);
        Part03.SetActive(true);
    }
    public void Next05()
    {
        Part02.SetActive(false);
        Part01.SetActive(true);
    }
    public void Part03ButtonClickecd()
    {
        SceneManager.LoadScene("Part03");
    }
    public void Next03()
    {
        Part03.SetActive(false);
        Part01.SetActive(true);
    }
    public void Next06()
    {
        Part03.SetActive(false);
        Part02.SetActive(true);
    }
}
