using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;



public class PlayerJump : MonoBehaviour
{

    private Rigidbody rb;
    [SerializeField] Camera cam;
    private bool isGrounded;
    public float gravity = -9.81f;
    [SerializeField] private float jumpHeight = 2000f;
    private bool jumpPressed = false;
    [SerializeField] public GameObject levelCompleted;
    private bool rightMouseHold;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        levelCompleted.SetActive(false);
    }

    private void FixedUpdate() {
        MovementJump();
    }

    private void Update() {
        if(isGrounded) {
            Time.timeScale = 1;
        }
 
        if(Input.GetMouseButtonDown(1)) {
            if(!isGrounded) {
                Time.timeScale = 0.1f;
                rightMouseHold = true;
            }
        }
            

        if(Input.GetMouseButtonUp(1)) {
            Time.timeScale = 1;
            rightMouseHold = false;
        }

    }

    void OnSpecialJump() {
        if(rightMouseHold) {
            Time.timeScale = 1;
            rb.AddForce(cam.transform.forward * 2000);
        }
    }

    void MovementJump() {
        // If on the ground, stop vertical movement
        if (jumpPressed && isGrounded) {
            rb.AddForce(new Vector3(0.0f, jumpHeight, 0.0f));
            jumpPressed = false;
        }

    }

    void OnJump() {
        if (rb.velocity.y < 0.3f && jumpPressed == false && isGrounded) {
            jumpPressed = true;
        } 
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Finish1")) {
            levelCompleted.SetActive(true);
        } else if (collision.gameObject.CompareTag("Finish2")) {
            levelCompleted.SetActive(true);
        } else if (collision.gameObject.CompareTag("Finish3")) { 
            levelCompleted.SetActive(true);
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