using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuSoundManager : MonoBehaviour
{
    public AudioSource soundEffectSource;
    public AudioClip buttonSound;

    public void ButtonSound()
    {
        soundEffectSource.PlayOneShot(buttonSound);
    }
}
