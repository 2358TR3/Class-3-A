using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTrigger : MonoBehaviour
{
    private bool isOnFire = false;
    public GameObject fireEffect; 

    // Start the fire
    public void StartFire()
    {
        if (!isOnFire)  
        {
            isOnFire = true;
            Debug.Log("Fire started!");
            if (fireEffect != null)
            {
                fireEffect.SetActive(true); 
            }
        }
    }

    
    public void ExtinguishFire()
    {
        if (isOnFire)
        {
            isOnFire = false;
            Debug.Log("Fire extinguished!");
            if (fireEffect != null)
            {
                fireEffect.SetActive(false);  
            }
        }
    }

    public bool IsOnFire()
    {
        return isOnFire;  
    }
}
