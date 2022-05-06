using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RespawnOnFall : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 spawnPoint = new Vector3();
    private float minHeightForDeath;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        minHeightForDeath = -30;
        spawnPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(rb.transform.position.y < minHeightForDeath) {
            SceneManager.LoadScene(1);
        }
    }
}