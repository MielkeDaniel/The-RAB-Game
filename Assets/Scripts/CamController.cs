using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class CamController : MonoBehaviour
{
 
    private const float YMin = -50.0f;
    private const float YMax = 50.0f;
 
    public Transform lookAt;
 
    public Transform Player;
 
    private float zoomMultiplier = 10f;
    public float targetZoom;
    private float currentX = 0.0f;
    private float currentY = 0.0f;
    private float sensivity = 1500f;

    Camera cam;

    

    void Start()
    {
        cam = gameObject.GetComponent<Camera>();
        cam.orthographicSize = 20f;
        targetZoom = cam.orthographicSize;
    }
 
    // Update is called once per frame
    void LateUpdate()
    {

        float scrollData = Input.GetAxis("Mouse ScrollWheel");

        targetZoom -= scrollData * zoomMultiplier;
        targetZoom = Mathf.Clamp(targetZoom, 4.5f, 30f);
        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, targetZoom, Time.deltaTime * 10);
 
        currentX += Input.GetAxis("Mouse X") * sensivity * Time.deltaTime;
        currentY += Input.GetAxis("Mouse Y") * sensivity * Time.deltaTime;
 
        currentY = Mathf.Clamp(currentY, YMin, YMax);
 
        Vector3 Direction = new Vector3(0, 0, -cam.orthographicSize);
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        transform.position = lookAt.position + rotation * Direction * -1;
 
        transform.LookAt(lookAt.position + new Vector3(0, 3, 0));
    }


}
 