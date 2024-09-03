using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScript : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform ShootDirection;
    private Rigidbody2D rb;
    public int bulletSpeed;
    public void Shoot()
    {
       GameObject Bullet = Instantiate(bulletPrefab, ShootDirection.position, Quaternion.identity);
       rb = Bullet.GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * bulletSpeed;
    }
}
