using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotionBlurEffect : MonoBehaviour
{
    private GameObject effect;
    private bool moduleEnabled;
    private Transform cam;
    // Start is called before the first frame update
    void Start()
    {
        effect = GameObject.Find("BlurEffect");
        cam = GameObject.Find("Main Camera").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
 
            effect.transform.position = cam.position + cam.forward * 3;
            effect.transform.rotation = cam.rotation;
       
      
 
    }

    void Mouse() {
        if (Input.GetMouseButtonDown(1) && Time.timeScale < 1) {
            moduleEnabled = true;
        }
        if (Time.timeScale == 1) {
            moduleEnabled = false;
        }
        if (Input.GetMouseButtonUp(1)) {
            moduleEnabled = false;
        }
    }
}
