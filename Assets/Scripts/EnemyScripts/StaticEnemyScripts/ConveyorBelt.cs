using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{

    public float speed = 30f;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    //This function takes the current position of the rigidbody and then slightly moves it in its forward direction and then sets it back to its starting position
    //This generates drag which creates the effect of a conveyor belt
    void FixedUpdate()
    {
        Vector3 pos = rb.position;
        rb.position += -transform.forward * speed * Time.fixedDeltaTime;
        rb.MovePosition(pos);
    }
}
