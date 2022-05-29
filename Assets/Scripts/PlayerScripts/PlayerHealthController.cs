using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    [SerializeField] Text healthCountText;

    void Start() {
        GameManager.instance.initHealthCount(healthCountText);
    }

    void OnParticleCollision(GameObject other) {
        if(other.tag == "Fire") {
            GameManager.instance.fireDamageHandler();
            GameManager.instance.initHealthCount(healthCountText);
        }
    }

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Heart")) {
            GameManager.instance.addHealth();
            GameManager.instance.initHealthCount(healthCountText);
            SFXManager.instance.playHeartPickup();
            Destroy(other.gameObject);
        }
    }

    void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.CompareTag("Arrow")) {
            GameManager.instance.arrowDamageHandler();
            GameManager.instance.initHealthCount(healthCountText);
        }
    }
}