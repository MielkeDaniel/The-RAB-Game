using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RespawnOnFall : MonoBehaviour
{
    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Water")) {
            GameManager.instance.handleLifeCount();
        }
    }
}