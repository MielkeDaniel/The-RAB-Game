using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{

    Text timerText;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.resetTimer();
        timerText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        GameManager.instance.countTimer(timerText);
    }
}
