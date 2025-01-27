using UnityEngine;
using System.Collections.Generic;

public class PreventPass : MonoBehaviour
{
    public List<GameObject> blockingObjects; // List of GameObjects that block the player

    private void OnTriggerEnter(Collider other)
    {
        // Check if the player is trying to pass through
        if (other.CompareTag("Player"))
        {
            // Check if any blocking object exists
            bool blockPlayer = false;

            foreach (GameObject obj in blockingObjects)
            {
                if (obj != null) // If the object exists
                {
                    blockPlayer = true;
                    break; // Stop checking further since one object is enough to block
                }
            }

            if (blockPlayer)
            {
                Debug.Log("You cannot pass through. One or more blocking objects exist.");
                // Optionally stop player movement
               Vector3 backPosition = other.transform.position - other.transform.forward * 1; // Push back slightly
                other.transform.position = backPosition;
            }
            else
            {
                Debug.Log("You can pass through!");
                // Allow the player to pass
            }
        }
    }
}
