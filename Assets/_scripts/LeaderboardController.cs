using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Controls the Leaderboard and Leaderboard screen 
/// </summary>
public class LeaderboardController : MonoBehaviour {
    //The leaderboard list
	static SortedList leaderboard;
    public static GameObject leaderboardCtrl;

    /// <summary>
    /// The max number of scores to keep in the leaderboard
    /// </summary>
    private const int MaxNumRecords = 10;

    //Buttons
	private Button backButton;
	private Button showButton;
	
    //Text UI objects
	private Text leaderboardNames;
	private Text leaderboardNumbers;


    // Use this for initialization
    void Start () {
        leaderboard = GameMaster.leaderboard;
        GameMaster.InitGame();

		leaderboardNames = GameObject.Find ("NameList").GetComponent<Text> ();
		leaderboardNumbers = GameObject.Find ("ScoreList").GetComponent<Text> ();

        //Create button listeners
        backButton = GameObject.Find("BackButton").GetComponent<Button> ();
		backButton.onClick.AddListener (ToggleLeaderboard);
        showButton = GameObject.Find("LeaderboardButton").GetComponent<Button> ();
		showButton.onClick.AddListener(ToggleLeaderboard);
		
        //Create leaderboard text 
        CreateLeaderboard();

        //Test button for adding random scores...
        Button testButton = GameObject.Find("TestButton").GetComponent<Button>();
        testButton.onClick.AddListener(testAdd);

        //Hide the leaderboard on gamestart
        gameObject.SetActive(false);
	}

	// Update is called once per frame
	void Update()
	{
        //If the leaderboard was updated, create the new leaderboard text.
        if (GameMaster.updated)
		{
			CreateLeaderboard();
		}
	}

    /// <summary>
    /// Toggles the leaderboard.
    /// </summary>
    void ToggleLeaderboard() {
        gameObject.SetActive(!gameObject.activeSelf);
    }

    /// <summary>
    /// Generates the Leaderboard text and shows it on the canvas
    /// </summary>
	private void CreateLeaderboard () {
        if (leaderboard.Count < 1) {
            leaderboardNames.text = "There are no scores!";
        }

		string names = "";
		string scores = "";
        int orderLabel = 1;

        //Scores are sorted from lowest to highest scores (reverse for loop)
        for (int i = 0; i < leaderboard.Count; i++ ) {
            GameMaster.LeaderboardScore val = (GameMaster.LeaderboardScore)leaderboard.GetByIndex(i);
            names += orderLabel.ToString() + "\t" + val.name + "\n";
            scores += val.score.ToTimestamp() + "\n";
			orderLabel++; 
        }

		leaderboardNames.text = names;
		leaderboardNumbers.text = scores;

        GameMaster.updated = false;
    }

    /// <summary>
    /// Tests adding to the leaderboard
    /// </summary>
	void testAdd()
	{
        GameMaster.AddToLeaderboard((int)Random.Range(0.0f, 100.0f), "Username" + leaderboard.Count.ToString());
	}

}
