using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndGameController : MonoBehaviour {

    public static bool winStatus = false;
    private GameObject winScreen;
    private GameObject loseScreen;
    public Text scoreText;
    public InputField usernameInput;

	public GameObject leaderboard;
    public Button submitScore;

    private EndScore currentScore;

    void Start()
    {
        winScreen = GameObject.Find("WinnerScreen");
        loseScreen = GameObject.Find("LoserScreen");

        Button exit = GameObject.Find("ButtonExit").GetComponent<Button>();
        exit.onClick.AddListener(ReturnToStart);

        Button restart = GameObject.Find("ButtonRestart").GetComponent<Button>();
        restart.onClick.AddListener(RestartGame);

        Button submit = GameObject.Find("SubmitScoreButton").GetComponent<Button>();
        submit.onClick.AddListener(SubmitScore);

        gameObject.SetActive(false);
        //private GameController gameController = GameController.Instance;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void ToggleEndGame(EndScore endScore)
    {
        Debug.Log("toggling end game");
        Debug.Log(endScore.winStatus);

        currentScore = endScore;

        winStatus = endScore.winStatus;
        scoreText.text = endScore.score.ToTimestamp();

        winScreen.SetActive(winStatus);
        loseScreen.SetActive(!winStatus);


        if (winStatus) {

        }

        Time.timeScale = 0;
    }

    void SubmitScore() {
        Debug.Log("toggling submit");

        GameMaster.AddToLeaderboard(currentScore.score, usernameInput.text);
    }

    void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Labyrinth");
    }

    void ReturnToStart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Start");
    }

    public class EndScore
    {
        public float score;
        public bool winStatus;
    }
}
