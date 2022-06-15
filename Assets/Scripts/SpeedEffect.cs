using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedEffect : MonoBehaviour
{
    private ParticleSystem vfx;
    private bool moduleEnabled;
    private Transform cam;
    private Rigidbody player;

    // Start is called before the first frame update
    void Start()
    {
        // Get the particle system, camera and palyer from the scene
        vfx = GetComponent<ParticleSystem>();
        cam = GameObject.Find("Main Camera").GetComponent<Transform>();
        player = GameObject.Find("Player").GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Module enabled means the velocity of the player is high enough to dispaly the speeding particle effect and transform its position
        // around the player
        if (moduleEnabled) {
            vfx.transform.position = cam.position + cam.forward * 60;
            vfx.transform.rotation = cam.rotation;
        }
        var emission = vfx.emission;
        emission.enabled = moduleEnabled;
        checkVelocity();
    }

    // Turn this variable to true, when the velocity of the play is high enough, so the particle system can be visible based on the state of the module
    void checkVelocity() {
        if (player.velocity.magnitude > 80) {
            moduleEnabled = true;
        } else {
            moduleEnabled = false;
        }
    }
}