using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    
    public static GameManager instance;     //Creating a singleton of this object

    [SerializeField]
    public int player1Score, player2Score;
    public float countdownTimer;

    public Text player1ScoreText, player2ScoreText;
    public Text countdownTimerText;

    public bool gameStarted;

    void Awake() {
        //If this Gamemanager does not exist, set this instance and don't destroy, else destroy
        if (instance == null) {
			instance = this;
            DontDestroyOnLoad(gameObject);
		}
		else {
			Destroy(gameObject);
		}

        player1Score = 0;
        player2Score = 0;
        player1ScoreText.text = " " + player1Score;
        player2ScoreText.text = " " + player2Score;
        
        countdownTimer = 4f;
        countdownTimerText.text = " ";

        gameStarted = false;
    }

    void Update() {
        if (!gameStarted) {
            BallController.instance.transform.position = new Vector3(0, 0.3114f, 0);
            countdownTimer -= Time.deltaTime;
            countdownTimerText.text = " " + countdownTimer.ToString("#.##");;

            if (countdownTimer <= 0) {
                gameStarted = true;
            }
        }
        else {
            countdownTimerText.text = " ";
        }
    }

    public void Player1Scored() {
        player1Score++;
        player1ScoreText.text = " " + player1Score;
        gameStarted = false;
        countdownTimer = 4f;
    }

    public void Player2Scored() {
        player2Score++;
        player2ScoreText.text = " " + player2Score;
        gameStarted = false;
        countdownTimer = 4f;
    }
}
