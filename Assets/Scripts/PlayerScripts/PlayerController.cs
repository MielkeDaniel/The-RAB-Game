using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private float speed = 35;
    private bool paused = false;
    private Transform cam;
    private bool isGrounded;
    private Rigidbody rb;
    GameObject pauseScreen;
    Vector2 movementVector;
    Vector2 lastMovement;

    // Keyboard movement data
    private float movementX;
    private float movementY;


    void Awake() {
        rb = GetComponent<Rigidbody>();
        cam = GameObject.Find("Main Camera").GetComponent<Transform>();
        pauseScreen = GameObject.Find("PauseScreen");
        Time.timeScale = 1;
    }

    // Start is called before the first frame update
    void Start()
    {   
        pauseScreen.SetActive(false);
        Debug.Log("start");
    }

    void OnPause() {
        
        if(!paused) {
            Time.timeScale = 0;
            this.paused = true;
            pauseScreen.SetActive(true);
        } else {
            this.paused = false;
            pauseScreen.SetActive(false);
            Time.timeScale = 1;
        }
    }

     public void onContinue() {
        pauseScreen.SetActive(false);
        Time.timeScale = 1;
    }

    private void OnMove(InputValue movementValue)
    {
        // Get Input movement from unitys new Input System
        movementVector = movementValue.Get<Vector2>();
        // safe to prefixed keyboard variables
        movementX = movementVector.x;
        movementY = movementVector.y;
        lastMovement = movementVector;
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        // Check if keyboard input movement is "existent", if so, calculate movement direction based on camera angle and add it as AddForce to the rb
        if (movement.magnitude >= 0.1f) {
            float targetAngle = Mathf.Atan2(movementX, movementY) * Mathf.Rad2Deg + cam.eulerAngles.y;
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            rb.AddForce(moveDir.normalized * speed);
        }
    }
}