using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterCollect : MonoBehaviour
{
    public string targetTag = "Water"; // Tag of the object to collide with and destroy

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(targetTag))
        {
            // Destroy the current object
            Destroy(gameObject);
        }
    }
}
