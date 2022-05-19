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

    private float slowMotionTimeScale = 0.4f;

    private float startTimeScale;
    private float startFixedDeltatime;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        levelCompleted.SetActive(false);

        startTimeScale = Time.timeScale;
        startFixedDeltatime = Time.fixedDeltaTime;
    }

    private void FixedUpdate() {
        MovementJump();
    }

    private void Update() {
        if(isGrounded) {
            StopSlowMotion();
        }
 
        if(Input.GetMouseButtonDown(1)) {
            if(!isGrounded) {
                StartSlowMotion();
                rightMouseHold = true;
            }
        }
            
        if(Input.GetMouseButtonUp(1)) {
            StopSlowMotion();
            rightMouseHold = false;
        }

    }

    void OnSpecialJump() {
        if(rightMouseHold) {
            StopSlowMotion();
            rb.AddForce(cam.transform.forward * 3000);
        }
    }

    void MovementJump() {
        // If on the ground, stop vertical movement
        if (jumpPressed && isGrounded) {
            rb.AddForce(new Vector3(0.0f, jumpHeight, 0.0f));
            jumpPressed = false;
        }

    }

    private void StartSlowMotion() {
        Time.timeScale = slowMotionTimeScale;
        Time.fixedDeltaTime = startFixedDeltatime * slowMotionTimeScale;
    }

        private void StopSlowMotion() {
        Time.timeScale = startTimeScale;
        Time.fixedDeltaTime = startFixedDeltatime;
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