using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    private static SoundManager _instance;
    public static SoundManager Instance { get { return _instance; } }

    //public AudioSource musicSource;
    public AudioSource musicSource;

    public AudioClip introTheme;
    public AudioClip backgroundTheme;

    public AudioClip rightAnswerSound;
    public AudioClip gameOverSound;
    public AudioClip winSound;
    
    private void Awake()
    {
        _instance = this;
        DontDestroyOnLoad(this.gameObject);

        ChangeMusic(0);
    }

    public void ChangeMusic(int sceneBuildIndex)
    {
        if (sceneBuildIndex == 0)
        {
            musicSource.clip = introTheme;
            musicSource.PlayDelayed(1.8f);
        }
        else if (sceneBuildIndex == 1)
        {
            musicSource.clip = introTheme;
            musicSource.Play();
        }
        else if (sceneBuildIndex == 2)
        {
            musicSource.clip = backgroundTheme;
            musicSource.Play();
        }
      
    }
    #region SoundEffects
    public void RightAnswerSound() { musicSource.PlayOneShot(rightAnswerSound); }

    public void GameOverSound() { musicSource.Stop(); musicSource.PlayOneShot(gameOverSound); }

    public void WinSound() { musicSource.Stop(); musicSource.PlayOneShot(winSound); }
    #endregion
}
