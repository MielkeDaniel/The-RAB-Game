using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;



public class PlayerJump : MonoBehaviour
{

    private Rigidbody rb;
    
    private bool isGrounded;
    public float gravity = -9.81f;
    [SerializeField] private float jumpHeight = 900f;
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
            rb.AddForce(new Vector3(0.0f, 1300f, 0.0f));
            jumpPressed = false;
        }

    }

    void OnJump() {
        if (rb.velocity.y < 0.3f && jumpPressed == false) {
            jumpPressed = true;
        } 
    }

    void OnCollisionStay(Collision collision) {
        if (collision.gameObject.CompareTag("Ground")) {
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision collision) {
        isGrounded = false;
    }
}
