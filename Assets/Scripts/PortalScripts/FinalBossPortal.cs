using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBossPortal : MonoBehaviour
{
    // Scripts in this folder could also be combined to one class by using a bool deciding on which triggerfunction to use
    // However this seemed to be the more sorted
    void OnTriggerEnter(Collider collider) {
        if (collider.gameObject.CompareTag("Player")) {
            SFXManager.instance.playTeleportSound();
            LevelManager.instance.StartFinalBoss();
            GameManager.instance.stageOneHighscoreCheck();
        }
    }
}
