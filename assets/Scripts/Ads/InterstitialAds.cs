using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using UnityEngine.UI;

public class InterstitialAds : MonoBehaviour
{
    private static InterstitialAds _instance;
    public static InterstitialAds Instance { get { return _instance; } }

    public string adID;
    public GameObject debugSystem;
    public bool debugSystemActivate = false;
    InterstitialAd interstitial;
    public Text bilgi, bilgii, bilgiii;
    public bool isActivate;

    private void Awake() { _instance = this; }

    public void Start()
    {
        if (debugSystemActivate)
        {
            debugSystem.SetActive(true);
        }
        else
        {
            debugSystem.SetActive(false);
        }
        RequestInterstitial();

        isActivate = true;

        StartCoroutine(Temizle());
    }

    void RequestInterstitial()
    {
#if UNITY_ANDROID
        string adUnitId = adID;
#elif UNITY_IPHONE
        string adUnitId = appID;
#else
        string adUnitId = "unexpected_platform";
#endif

        // Initialize an InterstitialAd.
        this.interstitial = new InterstitialAd(adUnitId);

        // Called when an ad request has successfully loaded.
        this.interstitial.OnAdLoaded += HandleOnAdLoaded;
        // Called when an ad request failed to load.
        this.interstitial.OnAdFailedToLoad += HandleOnAdFailedToLoad;
        // Called when an ad is shown.
        this.interstitial.OnAdOpening += HandleOnAdOpened;
        // Called when the ad is closed.
        this.interstitial.OnAdClosed += HandleOnAdClosed;
        // Called when the ad click caused the user to leave the application.
        this.interstitial.OnAdLeavingApplication += HandleOnAdLeavingApplication;

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the interstitial with the request.
        this.interstitial.LoadAd(request);
        bilgi.text = "Reklam İstendi";
        StartCoroutine(Temizle());
    }
    public void HandleOnAdLoaded(object sender, EventArgs args)
    {
        bilgi.text = "Reklam Yüklendi";
        Debug.Log("Reklam Yüklendi Hacı Abi...");
    }

    public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {

        StartCoroutine(Temizle());
        bilgi.text = "Reklam Yüklennmedi";
        Debug.Log("Reklam Yüklenmediyse Tekrar Yüklerim Hacı Abi...");
        //Yüklenemediyse Tekrar Yüklemeyi Denesin
        RequestInterstitial();
    }

    public void HandleOnAdOpened(object sender, EventArgs args)
    {

        Debug.Log("Reklam Açıldı Hacı Abi...");
        //Gösterildikten Sonra Tekrar Reklam Yüklesin
        RequestInterstitial();        
    }

    public void HandleOnAdClosed(object sender, EventArgs args)
    {

        Debug.Log("Reklamı Kapattın Hacı Abi...");
    }

    public void HandleOnAdLeavingApplication(object sender, EventArgs args)
    {

        Debug.Log("Napıyon Hacı Abi yaa...");
    }
    public void ReklamiGoster()
    {
        // if (isActivate)
        // {
        StartCoroutine(Temizle());
            bilgii.text = "Reklam Gösterilecek";
            if (this.interstitial.IsLoaded())
            {
                this.interstitial.Show();
                bilgii.text = "Reklam Gösteriliyor";
                isActivate = false;
                Debug.Log("REKLAM NERDE :D");
            }
            else
            {
                bilgiii.text = "Reklam Açılmadı";
            }
       // }
    }
    IEnumerator Temizle()
    {
        yield return new WaitForSeconds(6);
        bilgi.text = "";
        bilgii.text = "";
        bilgiii.text = "";
    }

    void Update()
    {
       
    }

    /*public void GecisReklamiGoster()
    {
        if (this.interstitial.IsLoaded())
        {
            this.interstitial.Show();
        }
    }*/

}
