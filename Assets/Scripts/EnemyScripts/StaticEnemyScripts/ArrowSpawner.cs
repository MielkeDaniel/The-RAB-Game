using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowSpawner : MonoBehaviour
{

    public float shotForce = 5000;
    public GameObject arrow;
    public float startDelay = 1f;
    public float shootIntervall = 2.5f;

    void Start()
    {
        // Start the intervall in which the particle effect will be turned on and off
        InvokeRepeating("ShootArrow", startDelay, shootIntervall);
    }

    // Instantiate an arrow, transform and rotate it to the right direction and shoot it forward with the given force
    // The arrow will be deleted from the scene after 10 seconds to prevent memory overflow
    void ShootArrow()
    {
        GameObject arrowInstance = Instantiate(arrow, transform.position, transform.rotation);
        arrowInstance.GetComponent<Rigidbody>().AddForce(transform.forward * shotForce);
        Destroy(arrowInstance, 10f);
    }
}
