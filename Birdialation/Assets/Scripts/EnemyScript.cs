using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyScript : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Crate"))
        {
            Destroy(gameObject);
            SceneManager.LoadScene("Part01");
        }
        else if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject);
            SceneManager.LoadScene("Part01");
        }
    }
}
