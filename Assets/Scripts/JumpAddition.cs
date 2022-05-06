using UnityEngine;
using System.Collections;

public class JumpAddition : MonoBehaviour
{
    public float fallMultiplier = 7.5f;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update() 
    {
        if (rb.velocity.y < 0.0f || rb.velocity.y > 0.0f) {
            rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
    }
}