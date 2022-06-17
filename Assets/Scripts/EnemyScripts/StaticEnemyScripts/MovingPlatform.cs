using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{

    public Vector3[] points;
    public float speed;
    public float delayTime;
    private int pointNumber = 0;
    private Vector3 currentTarget;
    private float delayStart;

    // Start is called before the first frame update
    void Start()
    {
        if(points.Length > 0) {
            currentTarget = points[0];
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position != currentTarget) {
            MovePlatform();
        } else {
            UpdateTarget();
        }
    }

    void MovePlatform() {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, currentTarget, step);
        if(transform.position == currentTarget) {
            delayStart = Time.time;
        }
    }

    void UpdateTarget() {
        if(Time.time - delayStart > delayTime) {
            NextPlatform();
        }
    }

    public void NextPlatform() {
        pointNumber++;
        if(pointNumber >= points.Length) {
            pointNumber = 0;
        }
        currentTarget = points[pointNumber];
    }

    void OnTriggerEnter(Collider other) {
        other.transform.parent = transform;
    }

    void OnTriggerExit(Collider other) {
        other.transform.parent = null;
    }
}