using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BuyManager : MonoBehaviour
{
    public LayerMask mask;

    [SerializeField]
    private int Offset = 2;

    private bool CanDRAW;

    private void Start()
    {
    }
    public void Buy()
    {
       Vector2 Origin = transform.position;

        RaycastHit2D hit = Physics2D.Raycast(Origin, Vector3.up *  Offset, mask);
        CanDRAW = true;

        if (hit.collider != null)
        {
            GameObject Lock = hit.collider.gameObject;
            Debug.Log(Lock.name);

        }
    }

    private void Update()
    {
        if (CanDRAW)
        {
            Debug.DrawLine(transform.position, Vector2.up * Offset, Color.red);
        }

    }
}
