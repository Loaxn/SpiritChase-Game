using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Import the TextMeshPro namespace to work with UI text elements

// This script updates the UI to display the number of collected crystals
public class CollectiblesUI : MonoBehaviour
{
    //component that displays the crystal count
    private TextMeshProUGUI crystalsText;

    // Start is called before the first frame update
    void Start()
    {
        // Get the TextMeshProUGUI component attached to this GameObject
        crystalsText = GetComponent<TextMeshProUGUI>();
    }

    // Method to update the text with the current number of collected crystals
    public void UpdateCrystalsText(PlayerCollectibles playerCollectibles)
    {
        // Convert the number of collected crystals to a string and display it in the UI
        crystalsText.text = playerCollectibles.NumberCristals.ToString();
    }
}
