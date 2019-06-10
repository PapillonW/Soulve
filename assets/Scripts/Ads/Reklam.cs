using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class Reklam : MonoBehaviour
{

    private InterstitialAd reklamObjesi;
    System.DateTime saat, saat2, saat3;
    bool reklam_geldimi = false;

    void Start()
    {
       // MobileAds.Initialize("ca-app-pub-5489432413164397~4086819287"); //BURAYI DOLDUR
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

        reklamObjesi = new InterstitialAd("ca-app-pub-3940256099942544/1033173712");  //BURAYI DOLDUR
        AdRequest reklamIstegi = new AdRequest.Builder().Build();
        reklamObjesi.LoadAd(reklamIstegi);

        StartCoroutine(ReklamiGoster());
    }

    IEnumerator ReklamiGoster()
    {
        while (!reklamObjesi.IsLoaded())
            yield return null;

        reklamObjesi.Show();
    }

    void reklam_Suresi()
    {
        saat = System.DateTime.Now;
        saat2 = saat.AddMinutes(1);
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
