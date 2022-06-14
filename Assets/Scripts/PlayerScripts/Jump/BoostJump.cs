using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class BoostJump : MonoBehaviour
{

    private Rigidbody rb;
    [SerializeField] Camera cam;
    private bool rightMouseHold;
    private float slowMotionTimeScale = 0.3f;
    private float cooldown = 0f;
    private float sliderCooldown = -2f;
    private float lastJump;

    private float startTimeScale;
    private float startFixedDeltatime;
    private bool superJumpAvailable;

    public Slider slider;

    PlayerJump playerJump;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerJump = rb.GetComponent<PlayerJump>();
        startTimeScale = Time.timeScale;
        startFixedDeltatime = Time.fixedDeltaTime;
        superJumpAvailable = true;
        slider.value = 2f;
    }


    private void Update() {
        if (IsOnCooldown()) {
            CooldownTimer();
            slider.value = cooldown + sliderCooldown;
        }

        if(Input.GetMouseButtonDown(1)) {
            if(!playerJump.isGrounded && superJumpAvailable && !IsOnCooldown()) {
                StartSlowMotion();
                rightMouseHold = true;
            }
        }
            
        if(Input.GetMouseButtonUp(1)) {
            StopSlowMotion();
            rightMouseHold = false;
        }

        
    }

    public void CooldownTimer() {
        cooldown -= Time.deltaTime;
        sliderCooldown += Time.deltaTime * 2;
    }

    private bool IsOnCooldown() {
        return cooldown > 0;
    }

    void OnSpecialJump() {
        if(rightMouseHold) {
            StopSlowMotion();
            rb.AddForce(cam.transform.forward * 1500 + new Vector3(0, 80, 0));
            superJumpAvailable = false;
            rightMouseHold = false;
            cooldown = 2f;
            sliderCooldown = -2f;
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