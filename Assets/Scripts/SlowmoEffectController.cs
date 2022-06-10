using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class SlowmoEffectController : MonoBehaviour
{
    private ParticleSystem vfx;
    private bool moduleEnabled;
    private Transform cam;
    // Start is called before the first frame update
    void Start()
    {
        vfx = GetComponent<ParticleSystem>();
        cam = GameObject.Find("Main Camera").GetComponent<Transform>();
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
        if (Input.GetMouseButtonDown(1)) {
            moduleEnabled = true;
        }
        if (Input.GetMouseButtonUp(1)) {
            moduleEnabled = false;
        }
    }
}
