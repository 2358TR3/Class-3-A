using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class WaterBucket : MonoBehaviour
{
    private bool hasBucket = false;  

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            hasBucket = true;  
            gameObject.SetActive(false);  
            Debug.Log("Player collected the water bucket.");
        }
    }

    public bool HasBucket()
    {
        return hasBucket;  
    }
}

