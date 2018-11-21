using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score_ScoreManager : MonoBehaviour {

    public List<HighScore> highscores = new List<HighScore>();

    public GameObject scorePrefab;
    public Transform scoreGrid;

    private int rank1 = 1;
    string name1 = "john";
    int score1 = 9000;

    int rank2 = 3;
    string name2 = "brooklyn";
    int score2 = 100000;

    int rank3 = 5;
    string name3 = "jacob";
    int score3 = 15;

    // Use this for initialization
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        GetScores();
    }

    public void GetScores(){
        //just clears the list of high scores
        highscores.Clear();
        //if(PlayerPrefs.HasKey("scores")){
        //    //highscores = PlayerPrefs.G
        //    //get stored variables from player prefs; This will be hella long if storing everything as their native type
        //}

        //could do something like if playerprefs has key scores exist? Then if they do then just get all of the data instead of constantly checking;
        //although what this presupposes is existant data for all of the queries. if we pass something into it then it should have default values
        //might need to create a reset button to make sure that everything exists before doing any checks

        highscores.Add(new HighScore(rank1, name1, score1));
        highscores.Add(new HighScore(rank2, name2, score2));
        highscores.Add(new HighScore(rank3, name3, score3));

        ShowScores();


        //add code here to get scores from playerPrefs
    }

    private void ShowScores(){
        for (int i = 0; i < highscores.Count; i++){
            GameObject tmpObj = Instantiate(scorePrefab);
            HighScore tmpScore = highscores[i];
            tmpObj.GetComponent<Score_ScoreObject>().SetScore(highscores[i].Rank.ToString(), highscores[i].Name, highscores[i].Score.ToString());
            tmpObj.transform.SetParent(scoreGrid);
            //tmpObj.GetComponent<RectTransform>().localScale = new Vector3(1,1,1);
        }
    }

	
	// Update is called once per frame
	void Update () {
		
	}
}
