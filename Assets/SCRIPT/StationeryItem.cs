using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationeryItem : MonoBehaviour
{
    public QuestManager questManager; // Reference to the QuestManager script
    public AudioClip pickUpSound; // Sound effect to play on pickup
    private AudioSource audioSource; // Reference to the AudioSource
    private bool isCollected = false; // Prevent duplicate triggers

    private void Start()
    {
        // Ensure there's an AudioSource component, or log a warning
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null && pickUpSound != null)
        {
            Debug.LogWarning("AudioSource is missing, but a pick-up sound is assigned.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isCollected)
        {
            // Ensure QuestManager is assigned
            if (questManager == null)
            {
                Debug.LogError("QuestManager is not assigned to the StationeryItem.");
                return;
            }

            // Check if the player is allowed to collect the item
            if (!questManager.IsQuestActive())
            {
                Debug.Log("You need to activate the quest before collecting items.");
                return;
            }

            isCollected = true; // Mark as collected to avoid duplicates
            Debug.Log("Stationery item collected!");

            // Play the pickup sound, if available
            if (pickUpSound != null && audioSource != null)
            {
                audioSource.PlayOneShot(pickUpSound);
            }

            // Notify the QuestManager
            questManager.CollectItem();

            // Destroy the object after a delay to allow the sound to finish
            Destroy(gameObject, pickUpSound != null ? pickUpSound.length : 0.1f);
        }
    }
}
