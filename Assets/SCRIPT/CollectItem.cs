using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectItem : MonoBehaviour
{
    public AudioClip collectSound; // Drag the audio clip here in the inspector
    private AudioSource audioSource;

    void Start()
    {
        // Get the AudioSource component attached to the item
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogWarning("AudioSource component not found on the item. Ensure it is attached!");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered the trigger zone!");

            // Play the collection sound
            if (audioSource != null && collectSound != null)
            {
                audioSource.PlayOneShot(collectSound);
            }

            // Search for WaterThrow component in the Player's children
            WaterThrow waterThrow = other.GetComponentInChildren<WaterThrow>();
            if (waterThrow != null)
            {
                waterThrow.Collect();
                Debug.Log("Item collected! Total items: " + waterThrow.itemCount);
            }
            else
            {
                Debug.LogWarning("WaterThrow component not found in the Player's hierarchy!");
            }

            // Destroy the item after collection
            Destroy(gameObject);
        }
    }
}
