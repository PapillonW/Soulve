using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class TimeManager : MonoBehaviour
{
    private static TimeManager _instance;
    public static TimeManager Instance { get { return _instance; } }

    GameOverManager gameOverManagerScript;
    NumbersManager numbersManagerScript;

    public float timeCount;
    public bool isBegun;
    public Text timeText;

    private void Awake()
    {
        _instance = this;
    }

    void Start()
    {
        gameOverManagerScript = GameOverManager.Instance;
        numbersManagerScript = NumbersManager.Instance;
        timeText.enabled = false;

        StartCoroutine(SetTimeCount());
    }


    IEnumerator SetTimeCount() { yield return new WaitForSeconds(1); timeCount = numbersManagerScript.countOfEnd * 5; timeText.enabled = true; }

    void Update()
    {

        if (timeCount > 10) { isBegun = true; }

        if (isBegun)
        {
            timeCount -= Time.deltaTime;
            timeText.text = Mathf.Round(timeCount).ToString();

            if (timeCount <= 10)
            {
                timeText.resizeTextMaxSize = 150;
            }
            if (timeCount <= 0)
            {
                gameOverManagerScript.ToLose();
                gameOverManagerScript.GameOver();
            }
        }
    }
}
