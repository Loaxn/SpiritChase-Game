using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnnemyController : MonoBehaviour
{
    [Header("Patrol")]
    [SerializeField] private Transform wayPoints;  // Waypoints the enemy will patrol between
    private int currentWaypoint;  // The index of the current waypoint

    [Header("Components")]
    NavMeshAgent agent;  // The NavMeshAgent component that controls the enemy's movement

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();  // Get the NavMeshAgent component on the enemy object
    }

    void Update()
    {
        // If the enemy has reached the current waypoint, move to the next one
        if (agent.remainingDistance <= 0.2f)
        {
            currentWaypoint++;  // Move to the next waypoint
            if (currentWaypoint >= wayPoints.childCount)
            {
                currentWaypoint = 0;  // Loop back to the first waypoint if we've reached the end
            }
            agent.SetDestination(wayPoints.GetChild(currentWaypoint).position);  // Set the new destination for the enemy
        }
    }

    // This method is called when another collider enters the trigger collider attached to the enemy
    private void OnTriggerEnter(Collider other)
    {
        // Check if the object that entered the trigger is the player
        if (other.CompareTag("Player"))  // Ensure the player has the "Player" tag
        {
            PlayerCollectibles player = other.GetComponent<PlayerCollectibles>();  // Get the PlayerCollectibles script attached to the player
            if (player != null)
            {
                // The player loses a crystal
                player.LoseOneCrystal();  // Call the method to reduce the player's crystal count

                // Play the visual red feedback effect
                PlayerDamageFeedback feedback = other.GetComponent<PlayerDamageFeedback>();  // Get the PlayerDamageFeedback component
                if (feedback != null)
                {
                    feedback.PlayFeedback();  // Play the red feedback effect when the player collides with the enemy
                }

                Debug.Log("Collision with enemy, crystal lost!");  // Output a message to the console
            }
        }
    }
}
