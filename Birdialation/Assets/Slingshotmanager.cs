using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slingshotmanager : MonoBehaviour
{
    public List<GameObject> SlingShotGameObject;

    public int shotsTaken;

    public GameObject losePanel;

    [Header("Insults")]
    public GameObject InsultsGameObject;
    public InsultsScript InsultsScript;

    void Start()
    {
        InsultsGameObject = GameObject.FindGameObjectWithTag("Insults");
        InsultsScript = InsultsGameObject.GetComponent<InsultsScript>();
    }
    private void Update()
    {
        for (int i = 0; i < SlingShotGameObject.Count; i++)
        {
            SlingShotGameObject[i].SetActive(i == 0);
        }
    }

    public void NextWeapon()
    {
        shotsTaken++;
        InsultsScript.Insult();
        if (shotsTaken < 10)
        {
            SlingShotGameObject.RemoveAt(0);
        }else if (shotsTaken >= 10)
        {
            //StartCoroutine(ShowLosePanel());
            print("You lose");
        }
        

    }

    IEnumerator ShowLosePanel()
    {
        yield return new WaitForSeconds(5);
        Instantiate(losePanel);
        shotsTaken = 0;
    }
}
