using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class CamController : MonoBehaviour
{
 
    private const float YMin = -80.0f;
    private const float YMax = 40.0f;
 
    public Transform lookAt;
 
    private float zoomMultiplier = 10f;
    public float targetZoom;
    private float currentX = 0.0f;
    private float currentY = 0.0f;
    private float sensivity = 1000f;

    Camera cam;

    

    void Start()
    {
        // get the cam object, set the targetZoom, which will be the zoom constant throughout the script 
        cam = gameObject.GetComponent<Camera>();
        targetZoom = 20f;
    }
 
    // Update is called once per frame
    void LateUpdate()
    {
        // get the mouse input to zoom in and out based on the input
        float scrollData = Input.GetAxis("Mouse ScrollWheel");
        
        // Multiplier for smoothing the zoom and make it faster, change the multiplier, if you want to make it slower or faster
        targetZoom -= scrollData * zoomMultiplier;
        // clamp the zoom to a min and max value, so the palyer can´t zoom out too far or zoom in too close
        targetZoom = Mathf.Clamp(targetZoom, 4.5f, 30f);

        // get the x and y mouse input axis to rotate the camera based on the input
        currentX += Input.GetAxis("Mouse X") * sensivity * Time.deltaTime;
        currentY += Input.GetAxis("Mouse Y") * sensivity * Time.deltaTime;
        // clamp the y axis to a min and max value, so the palyer can´t rotate the camera upside down
        currentY =  Mathf.Clamp(currentY, YMin, YMax);
 
        // invert the x axis, so the camera rotates around the other way
        // rotate the camera based on the x and y input -> Returns an angle, to which the camera is 
        // located on a sphere, that way we can transform the camera:
        // 1. to the position of the object to look at
        // 2. to the rotation in the angle of the object to look at
        // 3. and finally multiply that vector by the distance (zoom) of the object to look at 
        Vector3 Zoom = Vector3.forward * targetZoom;
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        transform.position = lookAt.position + rotation * Zoom;
 
        // finally lift the camera position by 3 units up, so the camera is not 100% centered on the sphere, but look slightly above it
        transform.LookAt(lookAt.position + new Vector3(0, 3, 0));
    }


}
 