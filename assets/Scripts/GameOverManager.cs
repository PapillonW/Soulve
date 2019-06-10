using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    private static GameOverManager _instance;
    public static GameOverManager Instance { get { return _instance; } }


    InterstitialAdManager interstitialAdManagerScript;
    //InterstitialAds interstitialAds;
    SaveScoreManager saveScoreManagerScript;
    ScoreManager scoreManagerScript;
    SoundManager soundManagerScript;  
    TimeManager timeManagerScript;
    UIManager uiManagerScript;


    public GameObject objectForScripts;

    public bool isWin;
    int adCount;

    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        interstitialAdManagerScript = InterstitialAdManager.Instance;
        //interstitialAds = InterstitialAds.Instance;
        saveScoreManagerScript = SaveScoreManager.Instance;
        scoreManagerScript = ScoreManager.Instance;
        soundManagerScript = SoundManager.Instance;
        timeManagerScript = TimeManager.Instance;
        uiManagerScript = UIManager.Instance;
    }

    public void ToVictory()
    {
        isWin = true;
        Destroy(objectForScripts.GetComponent<TimeManager>());
        scoreManagerScript.mainScore += (int)timeManagerScript.timeCount * 2;
        soundManagerScript.WinSound();

    }

    public void ToLose()
    {
        soundManagerScript.GameOverSound();
        Destroy(objectForScripts.GetComponent<TimeManager>());
        if (PlayerPrefs.GetInt("Vibration") == 1) Handheld.Vibrate();
    }

    public void GameOver()
    {
       /* adCount = PlayerPrefs.GetInt("adCount");
        adCount++;
        Debug.Log( "SAYISI 1:  " + adCount);
        PlayerPrefs.SetInt("adCount", ++adCount);
        Debug.Log("sayı Kaydı:  " + PlayerPrefs.GetInt("adCount"));
        if (PlayerPrefs.GetInt("adCount") >= 3)
        {
            //interstitialAdManagerScript.isActivatedAd = true;
            //interstitialAds.isActivate = true;
            //interstitialAds.ReklamiGoster();
            adCount = 0;
            PlayerPrefs.SetInt("adCount", adCount);

        }*/
        saveScoreManagerScript.SaveScore(scoreManagerScript.mainScore);
        if (isWin)
        {
            uiManagerScript.Victory();
        }
        else
        {

            uiManagerScript.GameOver();
        }
    }
}
