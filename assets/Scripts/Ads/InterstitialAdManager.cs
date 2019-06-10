using UnityEngine;
using System.Collections;
using GoogleMobileAds.Api;
public class InterstitialAdManager : MonoBehaviour
{
    private static InterstitialAdManager _instance;
    public static InterstitialAdManager Instance { get { return _instance; } }

    private InterstitialAd reklamObjesi;
    System.DateTime saat, saat2, saat3;
    bool reklam_geldimi = false;

  // public bool isActivatedAd;

    private void Awake() { _instance = this; }

    void Start()
    {
        //isActivatedAd = true;
        MobileAds.Initialize("ca-app-pub-5489432413164397~4086819287"); //BURAYI DOLDUR
    }

    private void Update()
    {
        reklam_Suresi();

        if (reklam_geldimi)
        {
            print("reklam gösterildi");
            reklam();
        }
    }

    public void reklam()
    {
        if (reklamObjesi != null)
            reklamObjesi.Destroy();

        reklamObjesi = new InterstitialAd("ca-app-pub-5489432413164397/4208617529");  //BURAYI DOLDUR
        AdRequest reklamIstegi = new AdRequest.Builder().Build();
        reklamObjesi.LoadAd(reklamIstegi);

        StartCoroutine(ReklamiGoster());

        /*if (isActivatedAd == true)
        {
            ReklamiGoster();
        }*/
    }

    IEnumerator ReklamiGoster()
    {
        while (!reklamObjesi.IsLoaded())
            yield return null;

        reklamObjesi.Show();

        //isActivatedAd = false;
    }

    void reklam_Suresi()
    {
        saat = System.DateTime.Now;
        saat2 = saat.AddMinutes(1f);
        print("reklam suresı çalıştırıldı");
        if (PlayerPrefs.HasKey("gecis_reklam"))
        {
            saat3 = System.DateTime.Parse(PlayerPrefs.GetString("gecis_reklam"));
            if (saat >= saat3)
            {
                reklam_geldimi = true;
                PlayerPrefs.SetString("gecis_reklam", saat2.ToString());
            }
            else
            {
                reklam_geldimi = false;
            }
        }
        else
        {
            reklam_geldimi = true;
            PlayerPrefs.SetString("gecis_reklam", saat2.ToString());
        }
        print(saat3);
    }
}