using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class is responsible for managing the background music throughout the game as it will not be destroyed when a new scene loads
public class BGMusicManager : MonoBehaviour
{

    public static BGMusicManager instance = null;

    public void Awake() {
        if(instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    
}
