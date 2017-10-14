using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SplashscreenController : MonoBehaviour {

    private GameObject starburst;
	private Button startButton;

	private AssetBundle myLoadedAssetBundle;
	private string[] scenePaths;

	// Use this for initialization
	void Start () {
        starburst = GameObject.Find("Starburst");
		startButton = GameObject.Find("StartButton").GetComponent<Button>();
		startButton.onClick.AddListener(StartGameScene);
	}

    private void StartGameScene() {
        SceneManager.LoadScene("Labyrinth");
    }
	
	// Update is called once per frame
	void Update () {
        starburst.transform.Rotate(new Vector3(0, 0, -2) * Time.deltaTime);
	}
}
