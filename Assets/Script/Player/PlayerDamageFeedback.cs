using System.Collections;
using UnityEngine;

public class PlayerDamageFeedback : MonoBehaviour
{
    [SerializeField] private Renderer playerRenderer;  // The Renderer of the player
    [SerializeField] private Color damageColor = Color.red;  // The color of the damage effect (red)
    [SerializeField] private float feedbackDuration = 0.2f;  // The duration of the feedback effect

    private Color originalColor;  // The original color of the player

    private void Start()
    {
        // Check if the playerRenderer is assigned and get the player's original color
        if (playerRenderer != null)
        {
            originalColor = playerRenderer.material.color;  // Store the player's original color
        }
    }

    // Method to trigger the red damage effect
    public void PlayFeedback()
    {
        StartCoroutine(DamageFeedbackCoroutine());  // Start the coroutine that handles the feedback effect
    }

    // Coroutine that changes the player's color to red and then back to the original color
    private IEnumerator DamageFeedbackCoroutine()
    {
        // If the playerRenderer is assigned, proceed with the effect
        if (playerRenderer != null)
        {
            playerRenderer.material.color = damageColor;  // Change the player's color to red
            yield return new WaitForSeconds(feedbackDuration);  // Wait for the defined duration
            playerRenderer.material.color = originalColor;  // Restore the player's original color
        }
    }
}
