using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{

    public Image[] tutorialImages;
    private int imageIndex;

    // Start is called before the first frame update
    void Start()
    {
        imageIndex = 0;
        for(int i = 0; i < tutorialImages.Length; i++) {
            if(i == imageIndex) {
                tutorialImages[i].enabled = true;
            } else {
                tutorialImages[i].enabled = false;
            }
         }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Tutorial")) {
            if(imageIndex <= 7) {
                imageIndex++;
            }
            for(int i = 0; i < tutorialImages.Length; i++) {
                if(i == imageIndex) {
                    tutorialImages[i].enabled = true;
                } else {
                    tutorialImages[i].enabled = false;
                }
         }
        }
        if (other.gameObject.CompareTag("Tutorial1")) {
            imageIndex = 2;
            for(int i = 0; i < tutorialImages.Length; i++) {
                if(i == imageIndex) {
                    tutorialImages[i].enabled = true;
                } else {
                    tutorialImages[i].enabled = false;
                }
         }
        }
    }
}
