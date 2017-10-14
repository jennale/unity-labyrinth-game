using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderboardController : MonoBehaviour {
    
	static SortedList leaderboard;
	private Button backButton;
	private Button showButton;

	private Text leaderboardNames;
	private Text leaderboardNumbers;
    private const int MAX_NUM_RECORDS = 10;

	private bool updated = false;

	// Use this for initialization
	void Start () {
		leaderboard = new SortedList ();
		leaderboardNames = GameObject.Find ("NameList").GetComponent<Text> ();
		leaderboardNumbers = GameObject.Find ("ScoreList").GetComponent<Text> ();

        backButton = GameObject.Find("BackButton").GetComponent<Button> ();
        backButton.onClick.AddListener (ToggleLeaderboard);

        Button testButton = GameObject.Find("TestButton").GetComponent<Button>();
        testButton.onClick.AddListener(testAdd);

        showButton = GameObject.Find("LeaderboardButton").GetComponent<Button> ();
        showButton.onClick.AddListener(ToggleLeaderboard);

		CreateLeaderboard();

        gameObject.SetActive(false);
	}

	// Update is called once per frame
	void Update()
	{
		if (updated)
		{
			CreateLeaderboard();
		}
	}

    void ToggleLeaderboard() {
        gameObject.SetActive(!gameObject.activeSelf);
    }

    /// <summary>
    /// Hides the leaderboard.
    /// </summary>
	void HideLeaderboard () {
		gameObject.SetActive (false);
	}

    /// <summary>
    /// Shows the leaderboard.
    /// </summary>
	void ShowLeaderboard () {		
		gameObject.SetActive (true);
	}

	void testAdd() {
        AddToLeaderboard ((int)Random.Range(0.0f, 100.0f), "Username" + leaderboard.Count.ToString());
	}

	private void CreateLeaderboard () {
        if (leaderboard.Count < 1) {
            leaderboardNames.text = "There are no scores!";
        }


		string names = "";
		string scores = "";
        int order = 1;

        for (int i = leaderboard.Count-1; i >= 0; i-- ) {
            Score val = (Score)leaderboard.GetByIndex(i);
            names += order.ToString() + "\t\t" + val.name + "\n";
            scores += val.score + "\n";
			order++; 
        }

		leaderboardNames.text = names;
		leaderboardNumbers.text = scores;

		updated = false;
	}

	public void AddToLeaderboard(int score, string user) {
        
		if (leaderboard.Count >= MAX_NUM_RECORDS) {
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
	

	internal class Score {
		public string name;
		public int score;
	}
}
