using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreManager : MonoBehaviour
{
    public Text highScoreShowText;

    void Start()
    {
        ShowHighScore(PlayerPrefs.GetInt("HighScore"));
    }

    public void ShowHighScore(int highScore) { highScoreShowText.text = highScore.ToString(); }
}
