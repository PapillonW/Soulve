using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckAnswerManager : MonoBehaviour
{
    CharacterMoveManager characterMoveManagerScript;
    GameOverManager gameOverManagerScript;
    NumbersManager numbersManagerScript;
    ScoreManager scoreManagerScript;
    SoundManager soundManagerScript;
    TimeManager timeManagerScript;


    public Sprite blueSprite;
    public Sprite greenSprite;
    public Sprite redSprite;

    public GameObject objectForScripts;

    private void Start()
    {
        characterMoveManagerScript = CharacterMoveManager.Instance;
        gameOverManagerScript = GameOverManager.Instance;
        numbersManagerScript = NumbersManager.Instance;
        scoreManagerScript = ScoreManager.Instance;
        soundManagerScript = SoundManager.Instance;
        timeManagerScript = TimeManager.Instance;
    }

    private void OnCollisionEnter(Collision collision)
    {    
        if (collision.gameObject.layer == 13) Correct(collision.gameObject);

        else if (collision.gameObject.layer == 14) Wrong(collision.gameObject);
    }

    public void Correct(GameObject collidedObject)
    {
        collidedObject.gameObject.layer = 10;
        collidedObject.GetComponentInChildren<Canvas>().enabled = false;
        scoreManagerScript.Score();
        numbersManagerScript.countOfEnd -= 1;
        soundManagerScript.RightAnswerSound();
        collidedObject.gameObject.GetComponent<SpriteRenderer>().sprite = greenSprite;
        characterMoveManagerScript.movementSpeed += characterMoveManagerScript.movementSpeed * 0.05f;
        
        if (numbersManagerScript.countOfEnd == 0)
        {
            gameOverManagerScript.ToVictory();
            StartCoroutine(GameOverBridge());
        }
    }

    public void Wrong(GameObject collidedObject)
    {
        gameOverManagerScript.ToLose();
        collidedObject.gameObject.GetComponent<SpriteRenderer>().sprite = redSprite;
        collidedObject.gameObject.AddComponent<Rigidbody>();
        collidedObject.gameObject.GetComponent<BoxCollider>().enabled = false;
        collidedObject.gameObject.transform.GetChild(0).gameObject.SetActive(false);
        gameObject.transform.SetParent(collidedObject.gameObject.transform);
        StartCoroutine(GameOverBridge());
    }

    IEnumerator GameOverBridge()
    {
        yield return new WaitForSeconds(2f);
        gameOverManagerScript.GameOver();
    }
}
