using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events; // Import UnityEvents to enable custom event handling

// This script allows us to keep track of how many crystals the player has collected
public class PlayerCollectibles : MonoBehaviour
{
    // Property to store the number of collected crystals.
    // - 'public' allows other scripts to read the value.
    // - 'private set' prevents direct modification from other scripts.
    public int NumberCristals { get; private set; }

    // UnityEvent to notify when crystals are collected. Can be used to trigger other actions.
    // PlayerCollectibles is passed as the argument, so listeners can access the instance.
    public UnityEvent<PlayerCollectibles> OnCristalsCollected;

    // This method is called when a crystal is collected. It increases the crystal count.
    public void CristalsCollected()
    {
        NumberCristals++; // Increment the number of collected crystals by 1.

        // Invoke the OnCristalsCollected event to notify other systems about the collection.
        // This passes 'this' (the current PlayerCollectibles instance) to listeners.
        OnCristalsCollected.Invoke(this);
    }
}

