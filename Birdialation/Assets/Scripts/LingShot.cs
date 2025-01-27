using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlingShot : MonoBehaviour
{
    public SpringJoint2D springJoint;      // Reference to the SpringJoint2D on the projectile
    public Rigidbody2D rb;                 // Reference to the Rigidbody2D of the projectile
    public Transform slingshotOrigin;      // Position of the slingshot anchor
    public float maxDragDistance = 3.0f;   // Maximum distance the projectile can be dragged
    public LineRenderer lineRenderer;      // Reference to the LineRenderer for the slingshot

    private bool isDragging = false;       // Flag to track whether the projectile is being dragged
    public GameObject newRock;


    [SerializeField]
    public GameObject WeaponPosition;
    public Slingshotmanager manager;

    [Header("Bazooka")]
    [SerializeField]
    private GameObject Bazooka;
    [SerializeField]
    private Explosion2D ExploadeScript;

    

    private void Start()
    {
        Bazooka = GameObject.FindGameObjectWithTag("Bazooka");
        WeaponPosition = GameObject.FindGameObjectWithTag("SJ");
        
        

        // Initialize LineRenderer if not set in the inspector
        if (lineRenderer == null)
        {
            lineRenderer = GetComponent<LineRenderer>();
        }

        // Set initial LineRenderer properties
        lineRenderer.positionCount = 2; // Two points: slingshot origin and projectile
        lineRenderer.enabled = false;  // Hide the line initially
    }

    private void Awake()
    {
        if (Bazooka != null)
        {
            ExploadeScript = GetComponent<Explosion2D>();
        }
        else { return; }
    }

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
                    lineRenderer.enabled = true; // Enable the line
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

                // Update LineRenderer positions
                lineRenderer.SetPosition(0, slingshotOrigin.position); // Start point: slingshot origin
                lineRenderer.SetPosition(1, rb.position);             // End point: projectile position
            }
            else if (touch.phase == TouchPhase.Ended && isDragging)
            {
                // Release the projectile
                isDragging = false;
                rb.isKinematic = false;  // Revert back to dynamic when the drag is over, allowing the physics to apply
                lineRenderer.enabled = false; // Hide the line
                StartCoroutine(Break());
                manager.shotsTaken++;
            }
        }
    }

    IEnumerator Break()
    {
        if (Bazooka != null)
        {
            
            yield return new WaitForSeconds(0.1f);
            Destroy(springJoint);
            yield return new WaitForSeconds(0.1f);
            
            manager.NextWeapon();

        }

        else
        {
            yield return new WaitForSeconds(0.1f);
            Destroy(springJoint);
            yield return new WaitForSeconds(2);
            manager.NextWeapon();
        }
    
        }

    bool IsTouchingProjectile(Vector2 touchPosition)
    {
        // Check if the touch is close to the projectile (you can adjust the distance check)
        return Vector2.Distance(touchPosition, rb.position) < 0.5f;
    }
}
