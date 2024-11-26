using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slingshotmanager : MonoBehaviour
{
    public List<GameObject> SlingShotGameObject;

    private void Update()
    {
        for (int i = 0; i < SlingShotGameObject.Count; i++)
        {
            SlingShotGameObject[i].SetActive(i == 0);
        }
    }

    public void NextWeapon()
    {
        SlingShotGameObject.RemoveAt(0);

    }
}
