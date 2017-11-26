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
    public Button submit;

    private EndScore currentScore;

    void Start()
    {
        winScreen = GameObject.Find("WinnerScreen");
        loseScreen = GameObject.Find("LoserScreen");

        Button exit = GameObject.Find("ButtonExit").GetComponent<Button>();
        exit.onClick.AddListener(ReturnToStart);

        Button restart = GameObject.Find("ButtonRestart").GetComponent<Button>();
        restart.onClick.AddListener(RestartGame);

        submit = GameObject.Find("SubmitScoreButton").GetComponent<Button>();
        submit.onClick.AddListener(SubmitScore);

        usernameInput.text = GameMaster.lastUser;

        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void ToggleEndGame(EndScore endScore)
    {
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
        GameMaster.lastUser = usernameInput.text;
        submit.interactable = false;
        submit.GetComponentsInChildren<Text>()[0].text = "Saved!";		
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
