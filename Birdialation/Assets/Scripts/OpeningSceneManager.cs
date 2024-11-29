using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpeningSceneManager : MonoBehaviour
{
    [SerializeField] private float delayBeforeLoad = 2f;

    private void Start()
    {
        StartCoroutine(LoadSceneAfterDelay("MainMenu"));
    }

    private IEnumerator LoadSceneAfterDelay(string MainMenu)
    {
        yield return new WaitForSeconds(delayBeforeLoad);
        SceneManager.LoadSceneAsync(MainMenu);
    }
}
