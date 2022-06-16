using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class MagicSphereController : MonoBehaviour
{
    private VisualEffect vfx;
    private bool moduleEnabled;
    private Transform cam;
    private Transform player;
    private GameObject playerLight;
    private Light playerLightComp;
    // Start is called before the first frame update
    void Start()
    {
        vfx = GetComponent<VisualEffect>();
        player = GameObject.Find("Player").GetComponent<Transform>();
        // set the default state of the visual effect to disabled
        vfx.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        // In case the effect/ module should be displayed, the transform of the effect is set to the position and rotation of the player
        Mouse();
        if (moduleEnabled) {
            vfx.transform.position = player.position;
            vfx.transform.rotation = player.rotation;
        }
    }

    // The effect should always be displayed, as long as the player has the right mouse button pressed, under the condition, that 
    // the player is able to perform the boost jump
    void Mouse() {
        // when the right mouse button is clicked, the timescale is set < 1, which can be used to decide if the effect should be displayed or not
        if (Input.GetMouseButtonDown(1) && Time.timeScale < 1) {
            moduleEnabled = true;
            vfx.Play();
        }
        // when the right mouse button is released or the player collides with the ground, the timescale is set to 1, which 
        // can be used to decide if the effect should be displayed or not
        if (Time.timeScale == 1) {
            moduleEnabled = false;
            vfx.Stop();
        }
    }
}