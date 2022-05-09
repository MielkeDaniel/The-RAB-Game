using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{

    Text timerText;
    [SerializeField]public float time = 30;

    // Start is called before the first frame update
    void Start()
    {
        timerText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(time > 0) {
            time -= Time.deltaTime;
        } else {
            time = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        DisplayTime(time);
    }

    void DisplayTime(float timeToDisplay) {
        if(timeToDisplay <= 0) {
            timeToDisplay = 0;
        }
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        float milliseconds = timeToDisplay % 1 * 100;

        timerText.text = "Time Remaining: " + string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, milliseconds);
    }
}
