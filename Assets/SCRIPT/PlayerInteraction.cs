using UnityEngine;
using UnityEngine.UI;

public class PlayerInteraction : MonoBehaviour
{
    public Camera playerCamera; // Reference to the player's camera
    public float interactionRange = 5f; // Max range for interaction
    public GameObject interactionPrompt; // UI prompt for "Press E to pick up"
    private HallwayTrash currentTrash; // Reference to the currently targeted trash

    private void Start()
    {
        if (interactionPrompt != null)
        {
            interactionPrompt.SetActive(false); // Hide prompt at the start
        }
    }

    private void Update()
    {
        CheckForTrash();
        HandleInteraction();
    }

    private void CheckForTrash()
    {
        // Perform a raycast from the center of the screen
        Ray ray = playerCamera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactionRange))
        {
            HallwayTrash trash = hit.collider.GetComponent<HallwayTrash>();

            if (trash != null) // If pointing at a trash object
            {
                currentTrash = trash;
                if (interactionPrompt != null)
                {
                    interactionPrompt.SetActive(true); // Show interaction prompt
                }
                return;
            }
        }

        // If no trash is found, reset
        currentTrash = null;
        if (interactionPrompt != null)
        {
            interactionPrompt.SetActive(false); // Hide interaction prompt
        }
    }

    private void HandleInteraction()
    {
        if (currentTrash != null && Input.GetKeyDown(KeyCode.E)) // Press E to interact
        {
            PlayerInventory playerInventory = GetComponent<PlayerInventory>();
            if (playerInventory != null)
            {
                playerInventory.CollectTrash();
                Destroy(currentTrash.gameObject); // Remove trash object
                currentTrash = null;
                if (interactionPrompt != null)
                {
                    interactionPrompt.SetActive(false); // Hide prompt
                }
            }
        }
    }
}

