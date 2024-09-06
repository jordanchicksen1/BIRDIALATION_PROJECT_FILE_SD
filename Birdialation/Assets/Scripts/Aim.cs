using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Aim : MonoBehaviour
{

    private Vector3 AimInput;
    public float rotationSpeed;
    // Start is called before the first frame update

    private void OnEnable()
    {
        var playerInput = new Controlls();

        playerInput.Player.Enable();

        playerInput.Player.Aim.performed += ctx =>AimInput = ctx.ReadValue<Vector2>(); // Update lookInput when look input is performed
        playerInput.Player.Aim.canceled += ctx => AimInput = Vector2.zero; // Reset lookInput when look input is canceled
    }

    // Update is called once per frame
    public void AimShot()
    {
        // Get horizontal and vertical look inputs and adjust based on sensitivity
        float AimZ = AimInput.x * rotationSpeed;


        // Diagonal rotation: Rotate the player object around the z-axis
        transform.Rotate(0, 0, AimZ);

        

    }

   
    private void Update()
    {
        AimShot();
        Debug.Log(AimInput);
        
    }
}
