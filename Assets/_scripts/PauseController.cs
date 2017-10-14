using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Button exit = GameObject.Find("ExitButton").GetComponent<Button>();
        Button restart = GameObject.Find("RestartButton").GetComponent<Button>();
        Button unpause = GameObject.Find("UnpauseButton").GetComponent<Button>();
        Button pause = GameObject.Find("PauseButton").GetComponent<Button>();

        exit.onClick.AddListener(ReturnToStart);
        restart.onClick.AddListener(RestartGame);
        unpause.onClick.AddListener(ContinueGame);
        pause.onClick.AddListener(PauseGame);

        gameObject.SetActive(false);
	}

	// Update is called once per frame
	void Update () {

	}

    void togglePausePanel () {
        gameObject.SetActive(!gameObject.activeSelf);
    }


    void PauseGame() {
        Time.timeScale = 0;
        togglePausePanel();
    }

    void ContinueGame() {
        Time.timeScale = 1;
        togglePausePanel();
    }

	void RestartGame() {
        Time.timeScale = 1;
		SceneManager.LoadScene("Labyrinth");
	}

    void ReturnToStart() {
        Time.timeScale = 1;
        SceneManager.LoadScene("Start");
    }
}
