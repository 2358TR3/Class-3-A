using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoTrash : MonoBehaviour
{
    public float trashTimer = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, trashTimer);
    }

}