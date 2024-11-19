using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScript : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform ShootDirection;
    private Rigidbody2D rb;
    public int bulletSpeed;

    [Header("Throw")]
    public GameObject Rock;
    public int rockSpeed;
    public int rockCount;
    public GameObject Controller;

    public void Shoot()
    {
       GameObject Bullet = Instantiate(bulletPrefab, ShootDirection.position, Quaternion.identity);
       rb = Bullet.GetComponent<Rigidbody2D>();
        rb.velocity = transform.forward * bulletSpeed;
    }

    public void Throw()
    {
        Rigidbody2D rb;
        GameObject Rocks = Instantiate(Rock, ShootDirection.position, Quaternion.identity);
        rb = Rocks.GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * rockSpeed;
        Rocks.transform.position = new Vector3(Rocks.transform.position.x, Rocks.transform.position.y, -0.03f);

    }
}
