using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;



public class WallJump : MonoBehaviour
{
    private Rigidbody rb;

    [SerializeField] private float jumpHeight = 600f;
    PlayerJump playerJump;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerJump = rb.GetComponent<PlayerJump>();
    }


    void OnCollisionStay(Collision collision) {   
        if (collision.gameObject.CompareTag("Wall") && !playerJump.isGrounded) {
            if (Input.GetKey("space")) {
                rb.AddForce(new Vector3(0.0f, jumpHeight, 0.0f) + collision.contacts[0].normal * 350);
            }
        }
    }
}