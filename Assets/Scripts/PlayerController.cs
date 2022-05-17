using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed = 15;
    public Transform cam;
    private bool isGrounded;
    private Rigidbody rb;
    [SerializeField] public GameObject pauseScreen;
    Vector2 movementVector;
    Vector2 lastMovement;

    // Keyboard movement data
    private float movementX;
    private float movementY;

    // Start is called before the first frame update
    void Start()
    {   
        rb = GetComponent<Rigidbody>();
        pauseScreen.SetActive(false);
        Time.timeScale = 1;
    }

    void OnPause() {
        if(Time.timeScale == 1){
            Time.timeScale = 0;
            pauseScreen.SetActive(true);
        } else{
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

    void OnCollisionStay(Collision collision) {
    
    }

    void OnCollisionExit(Collision collision) {
            
        }
}