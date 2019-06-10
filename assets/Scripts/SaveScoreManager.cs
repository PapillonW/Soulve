using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveScoreManager : MonoBehaviour
{
    private static SaveScoreManager _instance;
    public static SaveScoreManager Instance { get { return _instance; } }

    public int lastHighScore;

    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        lastHighScore = PlayerPrefs.GetInt("HighScore");
        Debug.Log(lastHighScore);
    }

    public void SaveScore(int highScore)
    {
        if (highScore > lastHighScore)
        {
            PlayerPrefs.SetInt("HighScore", highScore);
        }
    }
}
