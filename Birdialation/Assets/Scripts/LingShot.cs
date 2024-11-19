using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlingShot : MonoBehaviour
{
    public SpringJoint2D springJoint;      // Reference to the SpringJoint2D on the projectile
    public Rigidbody2D rb;                 // Reference to the Rigidbody2D of the projectile
    public Transform slingshotOrigin;      // Position of the slingshot anchor
    public float maxDragDistance = 3.0f;   // Maximum distance the projectile can be dragged

    private bool isDragging = false;       // Flag to track whether the projectile is being dragged

    void Update()
    {
        // Detect touch input on mobile
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

            if (touch.phase == TouchPhase.Began)
            {
                // Check if the touch is on the projectile
                if (IsTouchingProjectile(touchPosition))
                {
                    isDragging = true;
                    rb.isKinematic = true;  // Make the object kinematic when dragging
                }
            }
            else if (touch.phase == TouchPhase.Moved && isDragging)
            {
                // While dragging, move the projectile with the touch, but limit the distance
                Vector2 dragVector = touchPosition - (Vector2)slingshotOrigin.position;

                if (dragVector.magnitude > maxDragDistance)
                {
                    dragVector = dragVector.normalized * maxDragDistance;
                }

                // Move the projectile to the drag position
                rb.position = (Vector2)slingshotOrigin.position + dragVector;
            }
            else if (touch.phase == TouchPhase.Ended && isDragging)
            {
                // Release the projectile
                isDragging = false;
                rb.isKinematic = false;  // Revert back to dynamic when the drag is over, allowing the physics to apply
                // The spring will now pull the projectile

                StartCoroutine(Break());
            }
           
        }
    }
    IEnumerator Break()
    {
        yield return new WaitForSeconds(0.1f);
        Destroy(springJoint);

    }
    bool IsTouchingProjectile(Vector2 touchPosition)
    {
        // Check if the touch is close to the projectile (you can adjust the distance check)
        return Vector2.Distance(touchPosition, rb.position) < 0.5f;
    }
}
