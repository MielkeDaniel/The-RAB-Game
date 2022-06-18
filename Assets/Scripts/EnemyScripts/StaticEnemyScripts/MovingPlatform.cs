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

    // At the start of this script the current Target is set to the first of the input positions
    void Start()
    {
        if(points.Length > 0) {
            currentTarget = points[0];
        }
    }

    //The Update methods checks if the platform has reached its target and if so switches the target to the next destination
    void Update()
    {
        if(transform.position != currentTarget) {
            MovePlatform();
        } else {
            UpdateTarget();
        }
    }

    //In this Method the platform is moved towards the target position with the given speed
    //If the platform has reached the target delayStart is set to the current time this is then used 
    //to make the platform wait at its position for the given delayTime
    void MovePlatform() {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, currentTarget, step);
        if(transform.position == currentTarget) {
            delayStart = Time.time;
        }
    }

    //This method sets the next target if the platform has waited for the given delayTime
    void UpdateTarget() {
        if(Time.time - delayStart > delayTime) {
            NextPlatform();
        }
    }

    //This method sets the currentTarget to the next Vector3 in the points Array
    //if there are no more targets it goes back to its starting position
    public void NextPlatform() {
        pointNumber++;
        if(pointNumber >= points.Length) {
            pointNumber = 0;
        }
        currentTarget = points[pointNumber];
    }

    //These OnTrigger methods set the player as a child of the platform as long as the player is on top of the platform
    //If the player was not set as a child of the platform the player would have to manually move with the platform
    void OnTriggerEnter(Collider other) {
        other.transform.parent = transform;
    }

    void OnTriggerExit(Collider other) {
        other.transform.parent = null;
    }
}