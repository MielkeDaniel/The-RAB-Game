using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    public Slider slider;

    void Start() {
        Debug.Log("counter");
        GameManager.instance.initHealthCount(slider);
    }

    void OnParticleCollision(GameObject other) {
        if(other.tag == "Fire") {
            GameManager.instance.fireDamageHandler();
            GameManager.instance.initHealthCount(slider);
        }
    }

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Heart")) {
            GameManager.instance.addHealth();
            GameManager.instance.initHealthCount(slider);
            SFXManager.instance.playHeartPickup();
            Destroy(other.gameObject);
        }
    }

    void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.CompareTag("Arrow")) {
            GameManager.instance.arrowDamageHandler();
            GameManager.instance.initHealthCount(slider);
        }
    }
}