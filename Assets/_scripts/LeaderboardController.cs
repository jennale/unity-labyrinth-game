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

	private bool updated = false;

    // Use this for initialization
    void Start () {
        //TODO: Replace the leaderboard with UserPreferences if there is one saved.
		leaderboard = new SortedList ();
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
		if (updated)
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
        for (int i = leaderboard.Count-1; i >= 0; i-- ) {
            Score val = (Score)leaderboard.GetByIndex(i);
            names += orderLabel.ToString() + "\t\t" + val.name + "\n";
            scores += val.score + "\n";
			orderLabel++; 
        }

		leaderboardNames.text = names;
		leaderboardNumbers.text = scores;

		updated = false;
	}

    /// <summary>
    /// Adds to leaderboard, using a sorted list. The list is sorted by
    /// the following order: Score (0000XX) > User > Date
    /// </summary>
    /// <param name="score">Score integer.</param>
    /// <param name="user">User.</param>
	public void AddToLeaderboard(int score, string user) {
        
		if (leaderboard.Count >= MaxNumRecords) {
			leaderboard.RemoveAt (0);
        } 

		var newScore = new Score ();
		newScore.name = user;
		newScore.score = score;

		string key = score.ToString("D8") + "0-" + user + System.DateTime.Now.ToString();

		try {
			leaderboard.Add (key, newScore);
		} catch (System.Exception e) {
			Debug.Log ("A score already exists with this info\n" + e.Message);
		}

		updated = true;
	}

    /// <summary>
    /// Tests adding to the leaderboard
    /// </summary>
	void testAdd()
	{
		AddToLeaderboard((int)Random.Range(0.0f, 100.0f), "Username" + leaderboard.Count.ToString());
	}


    /// <summary>
    /// Score object.
    /// </summary>
	internal class Score {
		public string name;
		public int score;
	}
}
