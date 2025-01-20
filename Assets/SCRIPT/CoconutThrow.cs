using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoconutThrow : MonoBehaviour
{

    public GameObject TrashObject;
    public float ThrowForce;
    
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            //audio here nya

            GameObject temp = Instantiate(TrashObject, transform.position, transform.rotation);
            Rigidbody rb = temp.GetComponent<Rigidbody>();
            rb.velocity = transform.TransformDirection(new Vector3(0, 0, ThrowForce));
            temp.name = "Trash";

            if (temp.GetComponent<Rigidbody> ()==null)
            {
                Debug.Log("Component Missing!");
                temp.AddComponent<Rigidbody>();

                Physics.IgnoreCollision(transform.root.GetComponent<Collider>(), temp.GetComponent<Collider>(), true);

                
            }
        }
    }
}
