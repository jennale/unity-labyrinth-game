using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour {

    GameObject panel;
    bool paused = false;

	// Use this for initialization
	void Start () {
        panel = GameObject.Find("PausePanel");

        Button exit = GameObject.Find("ExitButton").GetComponent<Button>();
		exit.onClick.AddListener(ReturnToStart);

        Button restart = GameObject.Find("RestartButton").GetComponent<Button>();
		restart.onClick.AddListener(RestartGame);

        Button unpause = GameObject.Find("UnpauseButton").GetComponent<Button>();
		unpause.onClick.AddListener(ContinueGame);
  
        Button pause = GameObject.Find("PauseButton").GetComponent<Button>();
		pause.onClick.AddListener(PauseGame);

        panel.SetActive(false);
	}

	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //PauseGame();
            if (paused) {
                ContinueGame();
            } else if (Time.timeScale != 0){
                PauseGame();
            }
        }
	}

    void togglePausePanel () {
        panel.SetActive(!panel.activeSelf);
    }


    void PauseGame() {
        Time.timeScale = 0;
        paused = true;
        togglePausePanel();
    }

    void ContinueGame() {
        Time.timeScale = 1;
        paused = false;
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
