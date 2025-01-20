using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ClassroomTrigger : MonoBehaviour
{
    public GameObject fireEffect; // Reference to the fire particle system
    private bool fireTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !fireTriggered)
        {
            Debug.Log("Player entered the classroom. Fire triggered!");
            TriggerFire();
        }
    }

    private void TriggerFire()
    {
        fireTriggered = true; // Prevent retriggering
        if (fireEffect != null)
        {
            fireEffect.SetActive(true); // Activate the fire effect
        }
    }

   
}
