using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;



public class BoostJump : MonoBehaviour
{

    private Rigidbody rb;
    [SerializeField] Camera cam;
    private bool rightMouseHold;
    private float slowMotionTimeScale = 0.4f;

    private float startTimeScale;
    private float startFixedDeltatime;
    private bool superJumpAvailable;

    PlayerJump playerJump;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerJump = rb.GetComponent<PlayerJump>();
        startTimeScale = Time.timeScale;
        startFixedDeltatime = Time.fixedDeltaTime;
        superJumpAvailable = true;
    }


    private void Update() {
        if(Input.GetMouseButtonDown(1)) {
            if(!playerJump.isGrounded && superJumpAvailable) {
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
            rb.AddForce(cam.transform.forward * 1500 + new Vector3(0, 80, 0));
            superJumpAvailable = false;
        }
    }

    void OnCollisionEnter(Collision collision) {
        StopSlowMotion();
        superJumpAvailable = true;
    }


    private void StartSlowMotion() {
        Time.timeScale = slowMotionTimeScale;
        Time.fixedDeltaTime = startFixedDeltatime * slowMotionTimeScale;
    }

    private void StopSlowMotion() {
        Time.timeScale = startTimeScale;
        Time.fixedDeltaTime = startFixedDeltatime;
    }
}