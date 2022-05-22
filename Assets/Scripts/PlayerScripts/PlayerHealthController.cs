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
        if(other.tag == "Player") {
            GameManager.instance.handleHealthCount();
            GameManager.instance.initHealthCount(healthCountText);
        }
        
    }
}