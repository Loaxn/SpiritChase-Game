using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 0.1f; // Player's movement speed
    [SerializeField] private Rigidbody rgbd;       // The Rigidbody component used for physics-based movement
    [SerializeField] private float jumpHeight;     // The height of the jump 

    // Private fields for movement and jumping
    private Vector2 MoveVector; 
    private bool Jump;          

    // Start is called once when the game starts 
    private void Start()
    {
        //Debug.Log("Speed from Inspector: " + _speed); 
    }

    
    private void Update()
    {
        Move(); // Calling the movement function 
    }

    // Reads movement input using the new Input System
    public void ReadMoveInput(InputAction.CallbackContext context)
    {
        MoveVector = context.ReadValue<Vector2>(); // Getting the movement vector (X and Y)
    }

    // Reads jump input from the new Input System
    public void ReadJumpInput(InputAction.CallbackContext context)
    {
        Jump = context.ReadValue<float>() > 0.1f; // If the jump button is pressed (> 0.1), set Jump to true
        Jumpp(); // Call the jump function 
    }
   



    // Handles player movement
    private void Move()
    {
        // Creating a movement direction vector
        Vector3 direction = new Vector3(MoveVector.x, 0f, MoveVector.y).normalized;

        if (direction.magnitude >= 0.1f) // Only move if the player is actually pressing something
        {
            // Calculate new position based on speed
            Vector3 moveDirection = direction * _speed * Time.deltaTime;

            // Move the Rigidbody to simulate movement with physics
            rgbd.MovePosition(rgbd.position + moveDirection);
        }

        Debug.Log("MoveVector: " + MoveVector + ", Speed: " + _speed); // Debugging movement 
    }



    // Handles the player's jump
    private void Jumpp()
    {
        // Checking if the player is pressing jump and if they are on the ground 
        if (Jump && Mathf.Abs(rgbd.velocity.y) < 0.01f)
        {
            Debug.Log("Jumping!"); // Just to check if the jump function is actually called
            // Applying force upwards to make the player jump, using physics gravity calculations
            rgbd.AddForce(Vector3.up * Mathf.Sqrt(jumpHeight * -2f * Physics.gravity.y), ForceMode.VelocityChange);
        }
    }
}
