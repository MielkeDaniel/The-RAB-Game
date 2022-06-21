using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class is responsible for managing the background music throughout the game as it will not be destroyed when a new scene loads
public class BGMusicManager : MonoBehaviour
{
    public static BGMusicManager instance = null;
    public AudioSource Music;

    public void Awake() {
        if(instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start() {
        if (PlayerPrefs.HasKey("MusicVol")) {
            Music.volume = PlayerPrefs.GetFloat("MusicVol") * 0.1f;
        } else {
            Music.volume = 0.019f;
        }
    }

    public void setVolume() {
        Music.volume = PlayerPrefs.GetFloat("MusicVol") * 0.1f;
    }
    
}
