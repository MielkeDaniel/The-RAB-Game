using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBossPortal : MonoBehaviour
{
    void OnTriggerEnter(Collider collider) {
        if (collider.gameObject.CompareTag("Player")) {
            SFXManager.instance.playTeleportSound();
            LevelManager.instance.StartFinalBoss();
        }
    }
}
