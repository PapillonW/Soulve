using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;
    public static UIManager Instance { get { return _instance; } }

    // UI objects in the main menu
    public GameObject creditsPanel;
    public GameObject highScorePanel;
    public GameObject rateUsPanel;
    public GameObject settingsPanel;
    public GameObject soulveObject;
    public GameObject tutorialPanel;

    // UI objects in the game
    public GameObject gameOverPanel;
    public GameObject mainGamePanel;
    public GameObject pausePanel;    
    public GameObject victoryPanel;
    public Text gameOverScoreText;

    // Objects in the game
    public GameObject floors;
    public GameObject floorBackground;

    SoundManager soundManagerScript;

    Scene scene;
    private void Awake()
    {
        _instance = this;       
    }

    private void Start()
    {
        soundManagerScript = SoundManager.Instance;       
    }

    #region Game
    public void PlayGame()
    {        
        SceneManager.LoadScene(2);
        Time.timeScale = 1;
        soundManagerScript.ChangeMusic(2);
    }  

    public void PauseGame()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
        mainGamePanel.SetActive(false);
        floors.SetActive(false);
        floorBackground.SetActive(false);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
        mainGamePanel.SetActive(true);
        floors.SetActive(true);
        floorBackground.SetActive(true);
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        gameOverScoreText.text = ScoreManager.Instance.mainScore.ToString();
        gameOverPanel.SetActive(true);
        mainGamePanel.SetActive(false);
        floors.SetActive(false);
        floorBackground.SetActive(false);
    }

    public void Victory()
    {
        Time.timeScale = 0;
        gameOverScoreText.text = ScoreManager.Instance.mainScore.ToString();
        victoryPanel.SetActive(true);
        floors.SetActive(false);
        floorBackground.SetActive(false);

    }
    #endregion

    #region Go Scenes: Methods for open a scene
    public void GoMainMenu()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
        soundManagerScript.ChangeMusic(1);
    }
    #endregion

    #region Main Menu UI
    //Credits Panel Control
    public void OpenCreditsPanel() { creditsPanel.SetActive(true); /*settingsPanel.SetActive(false);*/ }

    public void CloseCreditsPanel() { creditsPanel.SetActive(false); }

    //High Score Panel Cotrol
    public void OpenHighScorePanel() { highScorePanel.SetActive(true); soulveObject.SetActive(false); }

    public void CloseHighScorePanel() { highScorePanel.SetActive(false); soulveObject.SetActive(true); }

    //Rate Us Panel Control
    public void OpenRateUsPanel() { rateUsPanel.SetActive(true); soulveObject.SetActive(false); }

    public void CloseRateUsPanel() { rateUsPanel.SetActive(false); soulveObject.SetActive(true); }

    //Settings Panel Control
    public void OpenSettingsPanel() { settingsPanel.SetActive(true); /*creditsPanel.SetActive(false);*/ soulveObject.SetActive(false); /*highScorePanel.SetActive(false);*/ }

    public void CloseSettingsPanel() { settingsPanel.SetActive(false); soulveObject.SetActive(true); }

    public void OpenTutorialPanel() { tutorialPanel.SetActive(true); }
    public void CloseTutorialPanel() { tutorialPanel.SetActive(false); }
    #endregion
}
