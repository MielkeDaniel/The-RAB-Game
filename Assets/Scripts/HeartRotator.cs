using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartRotator : MonoBehaviour
{

    private Vector3 rotation;
    private float speed = 2;
    private float y;

    // Start is called before the first frame update
    void Start()
    {
        rotation = new Vector3(0, 100, 0);
        y = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        // Rotate the object itself on the Y-axis and let it bounce up and down by using the PingPong function
        transform.Rotate(rotation * Time.deltaTime);
        y += Mathf.PingPong(Time.time * speed, 1) * 0.02f - 0.01f;
        transform.position = new Vector3(transform.position.x, y, transform.position.z);
        
    }
}
