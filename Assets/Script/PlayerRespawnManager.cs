using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerRespawnManager : MonoBehaviour
{
    [SerializeField] private string m_MyMessage;// how low the player can fall before respawning
    [SerializeField] private float m_Threshold; // Store the starting position of the player 
    Vector3 m_Origin;
    // This is the player controller that will help control the player’s movements
    PlayerController m_PlayerController;


    // Property to get the message, but we can't change it from outside the class
    public string MyMessage
    {
        get { return m_MyMessage; } // Just returns the message
        private set { m_MyMessage = value; } // This sets the message, but only inside this class
    }

    // This gets called when the script first starts (before anything happens in the game)
    private void Awake()
    {
        // Getting the PlayerController from the object this script is attached to
        m_PlayerController = GetComponent<PlayerController>();
    }

    // This gets called when the game starts (after everything is set up)
    void Start()
    {
        // Saving the player's starting position so we can use it for respawning later
        m_Origin = transform.position;
    }

    void Update()
    {
        // Check if the player falls below the threshold 
        if (transform.position.y < m_Threshold)
        {
            //Debug.Log("GameOver"); 
            Respawn(); // Call the respawn function
        }
    }

    // This is called when the player presses a button to respawn (input from the player)
    public void OnRespawn(InputValue value)
    {
        //Debug.Log("On Respawn");
        Respawn(); // Call the respawn function
    }

    // This function actually resets the player’s position to the starting point
    private void Respawn()
    {
        m_PlayerController.enabled = false; // Disable player movement so they don't move while respawning
        transform.position = m_Origin; // Move the player back to the starting position
        m_PlayerController.enabled = true; // Enable the player controller again so they can move
    }

    // This gets called at a fixed time (used for physics updates, but here we just print something)
    private void FixedUpdate()
    {
        //Debug.Log("FixedUpdate " + Time.deltaTime); 
    }
}
