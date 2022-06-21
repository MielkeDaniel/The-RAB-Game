using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public Slider sensitivity;
    public Slider MusicVol;
    private GameObject settings;
    private GameObject menu;

    // Start is called before the first frame update
    void Start()
    {
        settings = GameObject.Find("Settings");
        menu = GameObject.Find("Menu");
        settings.SetActive(false);
        if (PlayerPrefs.HasKey("MouseSens")) {
            sensitivity.value = PlayerPrefs.GetFloat("MouseSens");
        }   else {
            sensitivity.value = 0.7f;
            PlayerPrefs.SetFloat("MouseSens", 0.7f);
        }
        if (PlayerPrefs.HasKey("MusicVol")) {
            MusicVol.value = PlayerPrefs.GetFloat("MusicVol");
        }   else {
            MusicVol.value = 0.7f;
            PlayerPrefs.SetFloat("MusicVol", 0.7f);
        }
    }

    //sets the Menu canvas inactive and the Settings canvas active
    public void OpenSettings() {
        menu.SetActive(false);
        settings.SetActive(true);
    }

    //sets the menu canvas active and the Settings canvas inactive
    public void CloseSettings() {
        saveSettings();
        settings.SetActive(false);
        menu.SetActive(true);
    }

    //Safe the settings in the palyer preferences so they will be safed, even after the application was closed
    public void saveSettings() {
        PlayerPrefs.SetFloat("MouseSens", sensitivity.value);
        PlayerPrefs.SetFloat("MusicVol", MusicVol.value);
        BGMusicManager.instance.setVolume();
    }
}
