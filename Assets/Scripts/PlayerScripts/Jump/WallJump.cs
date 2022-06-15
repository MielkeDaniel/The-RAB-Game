using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;



public class WallJump : MonoBehaviour
{
    private Rigidbody rb;

    [SerializeField] private float jumpHeight = 600f;
    PlayerJump playerJump;
    public bool wallJumped = false;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // This reference is needed to access the grounded state of the player
        playerJump = rb.GetComponent<PlayerJump>();
    }


    // 1. Check if the player is grounded and has contact to a wall
    // 2. If the space (jumpbutton) is pressed
    // 2.1 set the walljumped varaible to true, so the player is unagile in the air (-> PlayerController Class)
    // 2.3 Add force to the Rigidbody in form of a vector to which consists out of an upwards vector, and the object´s normal vector 
    // the player colided with at the point of contact 
    void OnCollisionStay(Collision collision) {   
        if (collision.gameObject.CompareTag("Wall") && !playerJump.isGrounded) {
            if (Input.GetKey("space")) {
                wallJumped = true;
                rb.AddForce(new Vector3(0.0f, jumpHeight, 0.0f) + collision.contacts[0].normal * 400);
                SFXManager.instance.playJumpSound();
            }
        }
    }

    // The PlayerController needs to know when the player has landed from the walljump, so the player can move freely again
    // -> hitting the ground again will reset the walljumped variable to false
    void OnCollisionEnter(Collision collision) {   
        if (collision.gameObject.CompareTag("Ground")) {
            wallJumped = false;
        }
    }
}