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

        exit.onClick.AddListener(ReturnToStart);

        restart.onClick.AddListener(RestartGame);

        //gameObject.SetActive(false);
	}

    void RestartGame() {
        SceneManager.LoadScene("Labyrinth");
    }

    void ReturnToStart() {
        SceneManager.LoadScene("Start");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
