using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWindCollider : MonoBehaviour
{

    private Rigidbody rb;
    private int windMultiplier = 1;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag == "WindArea")
        {
            rb.velocity += collision.gameObject.GetComponent<WindArea>().direction * windMultiplier;
        }
    }
}