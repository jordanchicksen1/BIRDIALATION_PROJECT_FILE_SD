using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InsultsScript : MonoBehaviour
{
    public List<string> Insults;
    public TextMeshPro InsultsText;
    private void Start()
    {
        
    }

    public void Insult()
    {
        string Insult = Insults[Random.Range(0, Insults.Count)];
        InsultsText.text = Insult;
    }

}
