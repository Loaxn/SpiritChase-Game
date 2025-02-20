using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events; 

// This script allows us to keep track of how many crystals the player has collected
public class PlayerCollectibles : MonoBehaviour
{
    // Property to store the number of collected crystals.
    public int NumberCristals { get; private set; }

    // UnityEvent to notify when crystals are collected
    // PlayerCollectibles is passed as the argument so listeners can access the instance
    public UnityEvent<PlayerCollectibles> OnCristalsCollected;

    // This method is called when a crystal is collected. It increases the crystal count.
    public void CristalsCollected()
    {
        NumberCristals++; // +1.

        // Invoke the OnCristalsCollected event to notify other systems about the collection.   
        OnCristalsCollected.Invoke(this);
    }
}

