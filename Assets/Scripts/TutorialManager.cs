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
        loadImages(imageIndex);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Tutorial")) {
            if(imageIndex <= 9) {
                imageIndex++;
            }
        }
        if (other.gameObject.CompareTag("Tutorial1")) {
            imageIndex = 2;
        }
        loadImages(imageIndex);
    }

    void loadImages(int index) {
        for(int i = 0; i < tutorialImages.Length; i++) {
                if(i == imageIndex) {
                    tutorialImages[i].enabled = true;
                } else {
                    tutorialImages[i].enabled = false;
                }
         }
    }
}
