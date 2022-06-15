using UnityEngine;
using System.Collections;

public class JumpAddition : MonoBehaviour
{
    public float fallMultiplier = 9f;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update() 
    {
        // This code will always run, in case the player has velocity in the y-axis, which in this game means, that he is about to fall
        // To make the jump feel more natural, the rigidbody´s velocity will be changed on the y axis, by applying gravity to it, and multiplying 
        // it by the fallMultiplier times Time.deltaTime, continuously increasing the speed downwards. 
        if (rb.velocity.y < 0.0f || rb.velocity.y > 0.0f) {
            rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier) * Time.deltaTime;
        }
    }
}