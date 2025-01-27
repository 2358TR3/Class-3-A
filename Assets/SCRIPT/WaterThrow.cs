using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterThrow : MonoBehaviour
{
    public GameObject TrashObject; // Prefab to be thrown
    public float ThrowForce ; // Force to throw the object
    public AudioClip throwSound; // Sound to play when throwing
    private AudioSource audioSource; // Reference to AudioSource
    public int itemCount = 0; // Tracks the number of collected items

    void Start()
    {
        // Assign AudioSource from the current GameObject
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogWarning("AudioSource component is missing on the GameObject.");
        }
    }

    void Update()
    {
        // Check for Q key press to throw
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (itemCount > 0) // Ensure the player has collected items
            {
                // Play throw sound if available
                if (audioSource != null && throwSound != null)
                {
                    audioSource.PlayOneShot(throwSound);
                }

                // Instantiate the TrashObject
                GameObject temp = Instantiate(TrashObject, transform.position, transform.rotation);

                // Add Rigidbody and set velocity
                Rigidbody rb = temp.GetComponent<Rigidbody>();
                if (rb == null)
                {
                    rb = temp.AddComponent<Rigidbody>();
                }
                rb.velocity = transform.TransformDirection(Vector3.forward * ThrowForce);

                // Set a unique name
                temp.name = "Water";

                // Ignore collision with the player
                Collider playerCollider = transform.root.GetComponent<Collider>();
                if (playerCollider != null && temp.GetComponent<Collider>() != null)
                {
                    Physics.IgnoreCollision(playerCollider, temp.GetComponent<Collider>(), true);
                }

                // Reduce item count after throwing
                itemCount--;
                Debug.Log("Item thrown! Remaining items: " + itemCount);
            }
            else
            {
                Debug.Log("No items to throw. Collect items first!");
            }
        }
    }

    // Call this function when the player collects an item
    public void Collect()
    {
        itemCount++;
        Debug.Log("Item collected! Total items: " + itemCount);
    }
}
