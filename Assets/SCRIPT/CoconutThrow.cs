using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoconutThrow : MonoBehaviour
{
    public GameObject TrashObject; // Prefab to be thrown
    public float ThrowForce; // Force to throw the object
    public AudioClip throwSound; // Sound to play when throwing
    private AudioSource audioSource; // Reference to AudioSource

    void Start()
    {
        // Assign AudioSource from the current GameObject
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            // Play throw sound
            if (audioSource != null && throwSound != null)
            {
                audioSource.PlayOneShot(throwSound);
            }

            // Instantiate the TrashObject
            GameObject temp = Instantiate(TrashObject, transform.position, transform.rotation);
            Rigidbody rb = temp.GetComponent<Rigidbody>();
            rb.velocity = transform.TransformDirection(new Vector3(0, 0, ThrowForce));
            temp.name = "Trash";

            if (temp.GetComponent<Rigidbody>() == null)
            {
                Debug.Log("Component Missing!");
                temp.AddComponent<Rigidbody>();

                Physics.IgnoreCollision(transform.root.GetComponent<Collider>(), temp.GetComponent<Collider>(), true);
            }
        }
    }
}
