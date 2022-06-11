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
        vfx = GetComponent<ParticleSystem>();
        cam = GameObject.Find("Main Camera").GetComponent<Transform>();
        player = GameObject.Find("Player").GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (moduleEnabled) {
            vfx.transform.position = cam.position + cam.forward * 60;
            vfx.transform.rotation = cam.rotation;
        }
        var emission = vfx.emission;
        emission.enabled = moduleEnabled;
        Mouse();
    }

    void Mouse() {
        if (player.velocity.magnitude > 65) {
            moduleEnabled = true;
        } else {
            moduleEnabled = false;
        }
    }
}
