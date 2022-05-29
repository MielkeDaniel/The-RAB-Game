using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;



public class PlayerJump : MonoBehaviour
{

    private Rigidbody rb;
    public bool isGrounded;
    public float jumpHeight = 600f;
    private bool jumpPressed = false;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate() {
        MovementJump();
    }

    void MovementJump() {
        // If on the ground, stop vertical movement
        if (jumpPressed && isGrounded) {
            rb.AddForce(new Vector3(0.0f, jumpHeight, 0.0f));
            jumpPressed = false;
        }
    }

    void OnJump() {
        if (!jumpPressed && isGrounded) {
            jumpPressed = true;
        } 
    }

    void OnCollisionStay(Collision collision) {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Slow")) {
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision collision) {
        isGrounded = false;
    }
}