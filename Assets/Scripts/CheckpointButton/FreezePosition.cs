using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezePosition : MonoBehaviour
{

    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();   
    }

    //This function is used to freeze the x and y position of a rigidbody in the local space
    void Update()
    {
        Vector3 localVelocity = transform.InverseTransformDirection(rb.velocity);
        localVelocity.x = 0;
        localVelocity.y = 0;
        rb.velocity = transform.TransformDirection(localVelocity);
    }
}
