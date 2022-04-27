using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed = 15;
    public Transform cam;
    
    private Rigidbody rb;

    // Keyboard movement data
    private float movementX;
    private float movementY;

    // Start is called before the first frame update
    void Start()
    {   
        rb = GetComponent<Rigidbody>();
    }

    private void OnMove(InputValue movementValue)
    {
        // Get Input movement from unitys new Input System
        Vector2 movementVector = movementValue.Get<Vector2>();
        // safe to prefixed keyboard variables
        movementX = movementVector.x;
        movementY = movementVector.y;
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