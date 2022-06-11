using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class MagicEffect : MonoBehaviour
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
        vfx.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        Mouse();
        if (moduleEnabled) {
            vfx.transform.position = player.position;
            vfx.transform.rotation = player.rotation;
        }
    }

    void Mouse() {
        if (Input.GetMouseButtonDown(1) && Time.timeScale < 1) {
            moduleEnabled = true;
            vfx.Play();
        }
        if (Time.timeScale == 1) {
            moduleEnabled = false;
            vfx.Stop();
        }
        if (Input.GetMouseButtonUp(1)) {
            moduleEnabled = false;
            vfx.Stop();
        }
    }
}
