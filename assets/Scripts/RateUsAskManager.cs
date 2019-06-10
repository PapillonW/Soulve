using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RateUsAskManager : MonoBehaviour
{
    // public GameObject rateUsPanel;
    UIManager uIManagerScript;
    int askCount;
    static int maxCount = 15 ;
    void Start()
    {
        uIManagerScript = UIManager.Instance;

        if (!PlayerPrefs.HasKey("RateAskCount"))
        {
            askCount = maxCount - 10;
            PlayerPrefs.SetInt("RateAskCount", askCount);
        }
        else if (PlayerPrefs.HasKey("RateAskCount"))
        {
            askCount = PlayerPrefs.GetInt("RateAskCount");
            askCount--;
            PlayerPrefs.SetInt("RateAskCount", askCount);

            if (askCount == 0)
            {
                uIManagerScript.OpenRateUsPanel();
                askCount = maxCount;
                PlayerPrefs.SetInt("RateAskCount", askCount);
            }
        }    
    }

    public void RemindLater() { PlayerPrefs.SetInt("RateAskCount", askCount--); }

    public void RateUsGooglePlay() { Application.OpenURL("https://play.google.com/store/apps/details?id=" + Application.identifier); }
}
