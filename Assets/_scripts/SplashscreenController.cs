using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// Controls the initial Start splashscreen
/// </summary>
public class SplashscreenController : MonoBehaviour {

	private Button startButton;
    private GameObject starburst;

	private AssetBundle myLoadedAssetBundle;
	private string[] scenePaths;

	void Start () {
		//Add button listener
		startButton = GameObject.Find("StartButton").GetComponent<Button>();
		startButton.onClick.AddListener(StartGameScene);

        //Add animation
        starburst = GameObject.Find("Starburst");
	}

    /// <summary>
    /// Load the main labyrinth game scene.
    /// </summary>
    private void StartGameScene() {
        SceneManager.LoadScene("Labyrinth");
    }
	
	// Update is called once per frame
	void Update () {
        //Fun little twirl of the starburst
        starburst.transform.Rotate(new Vector3(0, 0, -2) * Time.deltaTime);
	}
}
