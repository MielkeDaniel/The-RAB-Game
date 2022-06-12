using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RespawnOnFall : MonoBehaviour
{
    [SerializeField] private Text lifeCountText;

    public Image[] hearts;
    private Rigidbody rb;
    private Vector3 spawnPoint = new Vector3();
    private float minHeightForDeath;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        minHeightForDeath = -30;
        spawnPoint = transform.position;
        GameManager.instance.initLifeCount(hearts);
    }

    // Update is called once per frame
    void Update()
    {
        if(rb.transform.position.y < minHeightForDeath) {
            GameManager.instance.handleLifeCount();
        }
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Water")) {
            GameManager.instance.handleLifeCount();
        }
    }
}