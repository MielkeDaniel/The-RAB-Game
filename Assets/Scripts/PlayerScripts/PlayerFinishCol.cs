using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;



public class PlayerFinishCol : MonoBehaviour
{

    private Rigidbody rb;
    GameObject levelCompleted;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        levelCompleted = GameObject.Find("LevelCompleted");
        levelCompleted.SetActive(false);
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Finish1")) {
            Time.timeScale = 0;
            levelCompleted.SetActive(true);
        } else if (collision.gameObject.CompareTag("Finish2")) {
            Time.timeScale = 0;
            levelCompleted.SetActive(true);
        } else if (collision.gameObject.CompareTag("Finish3")) { 
            Time.timeScale = 0;
            levelCompleted.SetActive(true);
        }
    }

}