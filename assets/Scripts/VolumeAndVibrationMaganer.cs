using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeAndVibrationMaganer : MonoBehaviour
{
    public GameObject vibrationOnButton;
    public GameObject vibrationOffButton;

    public Slider volumeSlider;
    public AudioSource musicSource;

    private void Awake()
    {
        musicSource = GameObject.Find("Dont Destroy Object").GetComponent<AudioSource>();

        if (PlayerPrefs.GetInt("Vibration") == 1 || !PlayerPrefs.HasKey("Vibration")) { vibrationOnButton.SetActive(true); vibrationOffButton.SetActive(false); }
        else if (PlayerPrefs.GetInt("Vibration") == 0) { vibrationOnButton.SetActive(false); vibrationOffButton.SetActive(true); }

        if (!PlayerPrefs.HasKey("Volume")) { volumeSlider.value = 0.5f; musicSource.volume = 0.5f; }
        else if (PlayerPrefs.HasKey("Volume")) { volumeSlider.value = PlayerPrefs.GetFloat("Volume"); musicSource.volume = PlayerPrefs.GetFloat("Volume"); }     
    }

    
    public void VibrationOn() { PlayerPrefs.SetInt("Vibration", 1); vibrationOnButton.SetActive(true); vibrationOffButton.SetActive(false); Handheld.Vibrate(); }
    public void VibrationOff() { PlayerPrefs.SetInt("Vibration", 0); vibrationOnButton.SetActive(false); vibrationOffButton.SetActive(true); Handheld.Vibrate(); }


    public void Volume(float volumeValue) { musicSource.volume = volumeValue; PlayerPrefs.SetFloat("Volume", volumeValue); }
}
