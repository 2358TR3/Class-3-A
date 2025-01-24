using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Door : MonoBehaviour
{
    public QuestManager questManager; // Reference to the QuestManager
    public GameObject doorClosedMessage; // Optional UI to show a message when the door is locked

    private void Start()
    {
        // Ensure the message UI is hidden initially
        if (doorClosedMessage != null)
            doorClosedMessage.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (questManager != null && questManager.AreAllItemsCollected())
            {
                OpenDoor();
            }
            else
            {
                ShowDoorClosedMessage();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && doorClosedMessage != null)
        {
            // Hide the message when the player leaves the door area
            doorClosedMessage.SetActive(false);
        }
    }

    private void OpenDoor()
    {
        Debug.Log("Door opened! All items have been collected.");
        // Add your door-opening logic here, e.g., animations or deactivating the door collider
        gameObject.SetActive(false); // Example: Deactivate the door GameObject
    }

    private void ShowDoorClosedMessage()
    {
        Debug.Log("The door is locked. Collect all items to proceed.");
        if (doorClosedMessage != null)
            doorClosedMessage.SetActive(true); // Show a locked message UI
    }
}
