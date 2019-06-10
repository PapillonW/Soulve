using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomColorManager : MonoBehaviour
{
    private static RandomColorManager _instance;
    public static RandomColorManager Instance { get { return _instance; } }


    Color randomColorValues;
    public int randomChoose;

    private void Awake()
    {
        _instance = this;
    }

    public Color RandomColor()
    {
        /*randomChoose = Random.Range(1, 7);

        switch (randomChoose)
        {
            case 1: randomColorValues = new Color(255, Random.Range(0, 256), 0); break;
            case 2: randomColorValues = new Color(255, 0, Random.Range(0, 256)); break;
            case 3: randomColorValues = new Color(Random.Range(0, 256), 255, 0); break;
            case 4: randomColorValues = new Color(Random.Range(0, 256), 0, 255); break;
            case 5: randomColorValues = new Color(0, 255, Random.Range(0, 256)); break;
            case 6: randomColorValues = new Color(0, Random.Range(0, 256), 255); break;
        }*/
        //randomColorValues = new Color(Random.value, Random.value, Random.value);


        



        return randomColorValues = Color.HSVToRGB(Random.value, 1, 1);
    }
}
