using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    Text timerText;

    void Start()
    {
        GameManager.instance.resetTimer();
        timerText = GetComponent<Text>();
        GameManager.instance.startTimer();
    }

    void Update()
    {
        if(SceneManager.GetActiveScene().name != "Tutorial" ) {
            GameManager.instance.countTimer(timerText);
        }
    }
}
