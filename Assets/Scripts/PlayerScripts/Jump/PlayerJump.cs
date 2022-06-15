using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;



public class PlayerJump : MonoBehaviour
{

    private Rigidbody rb;
    public bool isGrounded;
    public float jumpHeight = 800f;
    private bool jumpPressed = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    // This function will be called every frame
    // It is responsible for checking if the player is grounded and the jumpkey was pressed. If so - the player will jump with the
    // set jumpheight
    void OnJump() {
        if (!jumpPressed && isGrounded) {
            if (jumpHeight > 800f) {
                // in case the jumpheight is higher than 800f, which is the casual jump height, the player will perform a super jump 
                // from a jump pad - object. The sound of that is a different one, which is why there is an if else statement before 
                // deciding which sound to play
                SFXManager.instance.playJumpPadSound();
            }   else {
                SFXManager.instance.playJumpSound();
            }
            rb.AddForce(new Vector3(0.0f, jumpHeight, 0.0f));
            jumpPressed = false;
        } 
    }


    // If the player collides with either a ground or a wall, the is grounded variable will be set to true
    void OnCollisionStay(Collision collision) {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Button")) {
            isGrounded = true;
        }
        // additional check for the jumppad, on collisionstay the isGrounded variable will be set to true and they jumpheight will be set to 2000f,
        // so the player will perform a super jump
        if (collision.gameObject.CompareTag("Jump")) {
            isGrounded = true;
            jumpHeight = 2000f;
        }
    }

    // each time the player exits a collision, the isGrounded variable will be set to false and the jumpheight will be resetted
    void OnCollisionExit(Collision collision) {
        jumpHeight = 800f;
        isGrounded = false;
    }
}