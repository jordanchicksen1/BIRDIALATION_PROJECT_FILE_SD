using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion2D : MonoBehaviour
{
    public float explosionRadius = 5.0f; // Radius of the explosion
    public float explosionForce = 10.0f; // Force of the explosion
    public LayerMask affectedLayers; // Layers to be affected by the explosion

    [SerializeField]
    private bool checkCollisions;
    public void Explode()
    {

        // Find all colliders in the explosion radius
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, explosionRadius, affectedLayers);

        if (colliders.Length > 0 )
        {
            checkCollisions = true;
        }
        else { return; }
        foreach (Collider2D collider in colliders)
        {
                // Calculate direction and apply force
            Vector2 direction = collider.transform.position - transform.position;
            collider.GetComponent<Rigidbody2D>().AddForce(direction * explosionForce);
            print("BOOOM");
        }

        // Optional: Play particle effect or destroy the explosion object
        Destroy(gameObject, 1f); // Clean up the explosion object after 1 second
    }

    

    private void OnDrawGizmosSelected()
    {
        // Visualize the explosion radius in the editor
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }

    public IEnumerator ExplodeDelay()
    {
        yield return new WaitForSeconds(0.1f);
        Explode();
    }

    public void messycode()
    {
        StartCoroutine(ExplodeDelay());
    }

   

    private void Update()
    {

        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, explosionRadius, affectedLayers);

        if (colliders.Length > 0)
        {
            checkCollisions = true;
            StartCoroutine(ExplodeDelay());
        }
        else if (colliders.Length == 0 )
        {
            checkCollisions = false;

        }

        if (checkCollisions)
        {
            print("Coliders detected");
        }
    }
}
