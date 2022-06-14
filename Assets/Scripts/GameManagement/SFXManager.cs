using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{

    public static SFXManager instance = null;
    public AudioSource Audio;
    public AudioClip heartPickup;
    public AudioClip jumpPadSound;
    public AudioClip teleportSound;
    public AudioClip boostJumpSound;
    public AudioClip slowMoSound;
    public AudioClip stopSlowMoSound;

    public void Awake() {
        if(instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } 
    }

    public void playHeartPickup () {
        Audio.PlayOneShot(heartPickup);
    }

    public void playJumpPadSound () {
        Audio.PlayOneShot(jumpPadSound);
    }

    public void playTeleportSound () {
        Audio.PlayOneShot(teleportSound);
    }

    public void playBoostJumpSound () {
        Audio.PlayOneShot(boostJumpSound);
    }

    public void playSlowMoSound () {
        Audio.PlayOneShot(slowMoSound);
    }

    public void playStopSlowMoSound () {
        Audio.PlayOneShot(stopSlowMoSound);
    }

}
