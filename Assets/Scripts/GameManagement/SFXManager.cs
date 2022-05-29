using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{

    public static SFXManager instance = null;
    public AudioSource Audio;
    public AudioClip heartPickup;

    public void Awake() {
        if(instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } 
    }

    public void playHeartPickup () {
        Audio.PlayOneShot(heartPickup);
    }
}
