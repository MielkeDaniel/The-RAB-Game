using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class BoostJump : MonoBehaviour
{
    // scene objects
    private Rigidbody rb;
    private Camera cam;
    PlayerJump playerJump;

    // time based variables
    private float sliderCooldown = -2f;
    private float cooldown = 0f;
    private float slowMotionTimeScale = 0.3f;
    private float startTimeScale;
    private float startFixedDeltatime;

    // booleans for state check
    private bool rightMouseHold; // the player can only perform the boost jump if the right mouse button is held so the player enters the matrix mode
    private bool superJumpAvailable;

    public Slider slider;

    // This script handles the main mechanic of the game. The player can perform a boostjump by holding the right mouse button and than 
    // pressing the left mouse button, launching him forward
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerJump = rb.GetComponent<PlayerJump>();
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        // arguably these variables could also miss out, since they can be set manually (for example Time.timeScale = 1f;)
        // However this seemed to be more readable
        startTimeScale = Time.timeScale;
        startFixedDeltatime = Time.fixedDeltaTime;
        superJumpAvailable = true;
        slider.value = 2f;
    }


    private void Update() {
        if (IsOnCooldown()) {
            CooldownTimer();
            //The cooldown slider value has to be at 0 when the cooldown is at its highest and the other way around
            slider.value = cooldown + sliderCooldown;
        }

        // if the player is in the air (not grounded), the superjump is available and not on cooldown, the player can enter the matrix mode
        // starting the slow motion (while the magic effect from the MagicEffect script) will enable the vfx effect because 
        // the timescale is set below 1
        if(Input.GetMouseButtonDown(1)) {
            if(!playerJump.isGrounded && superJumpAvailable && !IsOnCooldown()) {
                SFXManager.instance.playSlowMoSound();
                StartSlowMotion();
                rightMouseHold = true;
            }
        }
        

        // In case the player does not perform the superjump and lets go of the right mouse button, is not grounded while the 
        // superjump would be available the slow motion (and vfx) is stopped
        if(Input.GetMouseButtonUp(1)) {
            if(!playerJump.isGrounded && superJumpAvailable) SFXManager.instance.playStopSlowMoSound();
            StopSlowMotion();
            rightMouseHold = false;
        }  
    }

    // The superjump has a 2 second cooldown so he can't be performed to fast in a row, making it more difficult for speedrunners to 
    // abuse the boost jump too much
    //To ensure that the cooldown slider is at the opposite value of the cooldown it gets added the deltaTime * 2
    //if this didnt happen the slider would be empty if the superjump was available
    public void CooldownTimer() {
        cooldown -= Time.deltaTime;
        sliderCooldown += Time.deltaTime * 2;
    }

    // returns whether the boostjump is on cooldown or not
    private bool IsOnCooldown() {
        return cooldown > 0;
    }

    // New Input System: Left Mouse Button
    // hitting the left mouse button will play the sound effect, stop the slowmotion and launch the player forward and slightly upwards
    void OnSpecialJump() {
        if(rightMouseHold) {
            SFXManager.instance.playBoostJumpSound();
            StopSlowMotion();
            rb.AddForce(cam.transform.forward * 1500 + new Vector3(0, 80, 0));

            // after the jump, the superJumpAvailable is set to false, so the player 
            // can't perform the superjump again until the cooldown is over and he enters slowmotion again
            superJumpAvailable = false;
            // reset values to initial state and set the jump on a 2sec cooldown
            rightMouseHold = false;
            cooldown = 2f;
            sliderCooldown = -2f;
        }
    }

    // Hitting the ground again will stop the matrix mode and set the superJumpAvailable to true again (while the player is in the air
    // he can´t perform the superjump again until he hits the ground (and the cooldown has run out))
    void OnCollisionEnter(Collision collision) {
            if (Time.timeScale < 0.9f) SFXManager.instance.playStopSlowMoSound();
            StopSlowMotion();
            superJumpAvailable = true;
    }


    // The slow motion can only be started if the timeScale is unequal to 0, which would mean in this game, that the pause screen is active
    private void StartSlowMotion() {
        if(Time.timeScale != 0) {
            Time.timeScale = slowMotionTimeScale;
            Time.fixedDeltaTime = startFixedDeltatime * slowMotionTimeScale;
        }
    }

    // The slow motion can only be left if the timeScale is unequal to 0, which would mean in this game, that the pause screen is active
    private void StopSlowMotion() {
        if(Time.timeScale != 0) {
            Time.timeScale = startTimeScale;
            Time.fixedDeltaTime = startFixedDeltatime;
        }
    }
}