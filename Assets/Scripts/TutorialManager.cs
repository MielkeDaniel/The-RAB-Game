using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{

    public Image[] tutorialImages;
    private int imageIndex;

    //Sets the image to the first tutorial image
    void Start()
    {
        imageIndex = 0;
        loadImages(imageIndex);
    }

    //Sets the imageIndex for the collider the player collided with
    void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Tutorial")) {
            imageIndex = 1;
        }
        if (other.gameObject.CompareTag("Tutorial1")) {
            imageIndex = 2;
        }
        if (other.gameObject.CompareTag("Tutorial2")) {
            imageIndex = 3;
        }
        if (other.gameObject.CompareTag("Tutorial3")) {
            imageIndex = 4;
        }
        if (other.gameObject.CompareTag("Tutorial4")) {
            imageIndex = 5;
        }
        if (other.gameObject.CompareTag("Tutorial5")) {
            imageIndex = 6;
        }
        if (other.gameObject.CompareTag("Tutorial6")) {
            imageIndex = 7;
        }
        if (other.gameObject.CompareTag("Tutorial7")) {
            imageIndex = 8;
        }
        if (other.gameObject.CompareTag("Tutorial8")) {
            imageIndex = 9;
        }
        loadImages(imageIndex);
    }

    //activates the image with the imageIndex and deactivates all other images
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
