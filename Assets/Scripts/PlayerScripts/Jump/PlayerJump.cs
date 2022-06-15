using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;



public class PlayerJump : MonoBehaviour
{

    private Rigidbody rb;
    public bool isGrounded;
    public float jumpHeight = 800f;
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
            if (jumpHeight > 800f) {
                SFXManager.instance.playJumpPadSound();
            }   else {
                SFXManager.instance.playJumpSound();
            }
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
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Button")) {
            isGrounded = true;
        }
        if (collision.gameObject.CompareTag("Jump")) {
            isGrounded = true;
            jumpHeight = 2000f;
        }
    }

    void OnCollisionExit(Collision collision) {
        jumpHeight = 800f;
        isGrounded = false;
    }
}