using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    Text timerText;
    int time = 0;

    // Start is called before the first frame update
    void Start()
    {
        if(SceneManager.GetActiveScene().name == "Level 1") {
            time = 0;
        }
        GameManager.instance.resetTimer(time);
        timerText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().name != "Tutorial" ) {
            GameManager.instance.countTimer(timerText);
        }
    }
}
