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

    PlayerJump playerJump;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerJump = rb.GetComponent<PlayerJump>();
        startTimeScale = Time.timeScale;
        startFixedDeltatime = Time.fixedDeltaTime;
    }


    private void Update() {
        if(Input.GetMouseButtonDown(1)) {
            if(!playerJump.isGrounded) {
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
            rb.AddForce(cam.transform.forward * 3000 + new Vector3(0, 80, 0));
        }
    }

    void OnCollisionEnter(Collision collision) {
        StopSlowMotion();
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