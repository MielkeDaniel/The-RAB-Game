using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowSpawner : MonoBehaviour
{

    public float shotForce = 5000;
    public GameObject arrow;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("ShootArrow", 1.0f, 2.5f);
    }

    // Update is called once per frame
    void ShootArrow()
    {
        GameObject arrowInstance = Instantiate(arrow, transform.position, transform.rotation);
        arrowInstance.GetComponent<Rigidbody>().AddForce(new Vector3(1, 0, 0) * shotForce);
        Destroy(arrowInstance, 10f);
    }
}
