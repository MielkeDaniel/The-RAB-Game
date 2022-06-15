using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// This class manages the sound effects of the game and is reachable from everywhere as a singleton 
// and will not be destroyed when a new scene loades
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
    public AudioClip jumpSound;
    public AudioClip buttonSound;

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

    public void playJumpSound () {
        Audio.PlayOneShot(jumpSound);
    }

    public void playButtonSound () {
        Audio.PlayOneShot(buttonSound);
    }

}
