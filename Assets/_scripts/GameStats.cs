using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameMaster {
    //The leaderboard list
    public static SortedList leaderboard = new SortedList();
    public static bool updated = false;

    public static string lastUser = "";


    /// <summary>
    /// The max number of scores to keep in the leaderboard
    /// </summary>
    private const int MaxNumRecords = 10;

	//// Use this for initialization
	//void Start () {
 //       DontDestroyOnLoad(gameObject);
	//}
	
	//// Update is called once per frame
	//void Update () {
		
	//}

    public static void AddToLeaderboard(float score, string user)
    {

        if (leaderboard.Count >= MaxNumRecords)
        {
            leaderboard.RemoveAt(MaxNumRecords - 1);
        }

        var newScore = new LeaderboardScore();
        newScore.name = user;
        newScore.score = (int)score;

        string key = ((int)score).ToString("D5") + "0-" + user + System.DateTime.Now.ToString();

        try
        {
            leaderboard.Add(key, newScore);
        }
        catch (System.Exception e)
        {
            Debug.Log("A score already exists with this info\n" + e.Message);
        }
        Debug.Log("hello");
        updated = true;
    }

    /// <summary>
    /// Score object.
    /// </summary>
    public class LeaderboardScore
    {
        public string name;
        public float score;
    }

}
