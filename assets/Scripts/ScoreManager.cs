using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private static ScoreManager _instance;
    public static ScoreManager Instance { get { return _instance; } }

    public int mainScore;

    private void Awake()
    {
        _instance = this;
    }

    public void Score() { mainScore += 10; }
}
