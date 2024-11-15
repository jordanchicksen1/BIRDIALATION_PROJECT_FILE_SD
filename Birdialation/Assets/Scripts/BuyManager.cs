using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BuyManager : MonoBehaviour
{
    public LayerMask mask;
    public LayerMask WeaponsLayer;
    public GameObject Weapon1, Weapon2, Weapon3, Weapon4, Weapon5, Weapon6;
    public GameObject HeldObject;

    [SerializeField]
    private int Offset = 2;


    private void Start()
    {
    }
    public void Buy()
    {
        Vector2 Origin = transform.position;

        RaycastHit2D hit = Physics2D.Raycast(Origin, Vector3.up * Offset, mask);

        if (hit.collider != null)
        {
            GameObject Lock = hit.collider.gameObject;
            if (Lock.name == "Weapon 1 Lock")
            {
                Destroy(Lock);
                Weapon1.SetActive(true);

            }
            else if (Lock.name == "Weapon 2 Lock")
            {
                Destroy(Lock);
                Weapon4.SetActive(true);

            }
            else if (Lock.name == "Weapon 3 Lock")
            {
                Destroy(Lock);
                Weapon2.SetActive(true);

            }
            else if (Lock.name == "Weapon 4 Lock")
            {
                Destroy(Lock);
                Weapon5.SetActive(true);

            }
            else if (Lock.name == "Weapon 5 Lock")
            {
                Destroy(Lock);
                Weapon3.SetActive(true);

            }
            else if (Lock.name == "Weapon 6 Lock")
            {
                Destroy(Lock);
                Weapon6.SetActive(true);

            }

        }
    }

    public void UseWeapon()
    {
        Vector2 Origin = transform.position;

        RaycastHit2D hit = Physics2D.Raycast(Origin, Vector3.up * Offset, WeaponsLayer);

        if (hit.collider != null)
        {

            GameObject Weapon = hit.collider.gameObject;
            Debug.Log(Weapon.name);


        }
    }
}
