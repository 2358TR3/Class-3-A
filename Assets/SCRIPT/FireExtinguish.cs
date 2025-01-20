using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FireExtinguish : MonoBehaviour
{
    public FireTrigger fireTrigger;  
    public WaterBucket waterBucket;  

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Player entered the extinguish zone.");

        if (other.CompareTag("Player") && fireTrigger.IsOnFire())  
        {
            Debug.Log("Fire is ON.");

            if (waterBucket.HasBucket())  
            {
                Debug.Log("Player has the water bucket, extinguishing the fire.");
                fireTrigger.ExtinguishFire();  
            }
            else
            {
                Debug.Log("Player needs the water bucket to extinguish the fire!");
            }
        }
    }
}

