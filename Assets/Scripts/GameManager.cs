using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;     //Creating a singleton of this object

    [Header("PUBLIC UI VARIABLES")]
    public int player1Score, player2Score;  //keep player scores
    public int maxScore;
    public float countdownTimer;            //game start timer

    [Header("PUBLIC UI TEXTS")]
    public Text player1ScoreText, player2ScoreText; //player score texts
    public Text multipurposeText;                 //Text for countdown and winner

    public bool gameStarted;

    public AudioSource audioSource;

    void Awake()
    {
        //If this Gamemanager does not exist, set this instance and don't destroy, else destroy
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        player1Score = 0;
        player2Score = 0;
        player1ScoreText.text = " " + player1Score;
        player2ScoreText.text = " " + player2Score;

        countdownTimer = 4f;
        multipurposeText.text = " ";

        gameStarted = false;
    }

    void Update()
    {
        if (!gameStarted)
        {
            BallController.instance.transform.position = new Vector3(0, 0.3114f, 0);
            countdownTimer -= Time.deltaTime;
            multipurposeText.text = " " + countdownTimer.ToString("#");
            multipurposeText.fontSize = 200;

            if (countdownTimer <= 0)
            {
                gameStarted = true;
            }
        }
    }

    public void Player1Scored()
    {
        player1Score++;
        player1ScoreText.text = " " + player1Score;
        if (player1Score >= maxScore)
        {
            EndGame("Player 1 Wins!");
            return;
        }
        gameStarted = false;
        countdownTimer = 4f;
    }

    public void Player2Scored()
    {
        player2Score++;
        player2ScoreText.text = " " + player2Score;
        if (player2Score >= maxScore)
        {
            EndGame("Player 2 Wins!");
            return;
        }
        gameStarted = false;
        countdownTimer = 4f;
    }
    void EndGame(string winner)
    {
        multipurposeText.text = winner;
        multipurposeText.fontSize = 100;
        multipurposeText.enabled = true;
        Invoke("LoadMainMenu", 3f);
    }

    void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    
    

}