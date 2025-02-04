using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// we want to detect the collision between the character and the crystals
public class CollectibleCollider : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object that collided is the Player
        PlayerCollectibles playerCollectibles = other.GetComponent<PlayerCollectibles>();

        if (playerCollectibles != null)
        {
            playerCollectibles.CristalsCollected(); // Add to the player's crystal count
            Destroy(gameObject); //  removes the collectible
        }
    }

}
