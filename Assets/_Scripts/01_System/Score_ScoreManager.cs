using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Score_ScoreManager : MonoBehaviour {

    public static Score_ScoreManager instance;
    public Score_SavedScoreData savedScores;

    //this is used to put scores into after reading from Score_SavedData
    //this needs to get passed back into Score_savedScoreData before serializing;
    public List<HighScore> highscores = new List<HighScore>();
   
    //this is used to store text boxes of score data on screen. It's not important;
    public List<GameObject> tempList = new List<GameObject>();
    [SerializeField]
    private CharacterCollisions characterCols;

    public GameObject scorePrefab;
    public Transform scoreGrid;
    //public Transform Canvas;
    public int numberOfDisplayedScores;

    public GameObject nameEntryboxPrefab;
    private GameObject nameEntryboxClone;

    public string playerSavedName;
    public int playerSavedScore;

    public string playerSetName;
    public int playerSetScore;

    [Header("Score Values")]
    public int jellyValue = 150;
    public int timeValue;
    public int clothesValue;

    [Header("Scores Saved")]
    public int jellyScore = 150;
    public int timeScore;
    public bool clothesBool = false;
    public bool needsNameUpdate = false;
    
    public int currentScore;
    [SerializeField]
    private GameObject clothes;

    private void Awake()
    {
        instance = this;


        //the below line is for resetting progress
        //PlayerPrefs.DeleteAll();
    }

    // Use this for initialization
    void Start()
    {
        //DontDestroyOnLoad(gameObject);
        Load();
        clothesBool = false;
        //GetScores();
        //ShowScores();
    }

    public void Save(){
        //this is setting the values in saved score data before serialising into the playerpreffs
        //PlayerPrefs.SetString("save", Score_Serializer.Serialize<Score_SavedScoreData>(savedScores));
        if (highscores[1] != null)
        {
            savedScores.name1 = highscores[0].Name;
            savedScores.score1 = highscores[0].Score;
            savedScores.name2 = highscores[1].Name;
            savedScores.score2 = highscores[1].Score;
            savedScores.name3 = highscores[2].Name;
            savedScores.score3 = highscores[2].Score;
            savedScores.name4 = highscores[3].Name;
            savedScores.score4 = highscores[3].Score;
            savedScores.name5 = highscores[4].Name;
            savedScores.score5 = highscores[4].Score;
            savedScores.name6 = highscores[5].Name;
            savedScores.score6 = highscores[5].Score;
            savedScores.name7 = highscores[6].Name;
            savedScores.score7 = highscores[6].Score;
            savedScores.name8 = highscores[7].Name;
            savedScores.score8 = highscores[7].Score;
            savedScores.name9 = highscores[8].Name;
            savedScores.score9 = highscores[8].Score;
            savedScores.name10 = highscores[9].Name;
            savedScores.score10 = highscores[9].Score;
            savedScores.playerName = playerSavedName;
            savedScores.playerScore = playerSavedScore;

        }

        PlayerPrefs.SetString("save", Score_Serializer.Serialize<Score_SavedScoreData>(savedScores));
    }
    

    public void Load()
    {
        if(PlayerPrefs.HasKey("save")){
            savedScores = Score_Serializer.Deserialize<Score_SavedScoreData>(PlayerPrefs.GetString("save"));
            playerSavedName = savedScores.playerName;
            playerSavedScore = savedScores.playerScore;
            Debug.Log("Loading and savedScores does exist");
        }

        else{
            savedScores = new Score_SavedScoreData();
            GetScores();
            Save();
            playerSavedName = savedScores.playerName;
            playerSavedScore = savedScores.playerScore;
            Debug.Log("No saved state found, created a new one");
        }  
    }

    public void GetScores(){
        highscores.Clear();
        highscores.Add(new HighScore(1, savedScores.name1, savedScores.score1));
        highscores.Add(new HighScore(2, savedScores.name2, savedScores.score2));
        highscores.Add(new HighScore(3, savedScores.name3, savedScores.score3));
        highscores.Add(new HighScore(4, savedScores.name4, savedScores.score4));
        highscores.Add(new HighScore(5, savedScores.name5, savedScores.score5));
        highscores.Add(new HighScore(6, savedScores.name6, savedScores.score6));
        highscores.Add(new HighScore(7, savedScores.name7, savedScores.score7));
        highscores.Add(new HighScore(8, savedScores.name8, savedScores.score8));
        highscores.Add(new HighScore(9, savedScores.name9, savedScores.score9));
        highscores.Add(new HighScore(10, savedScores.name10, savedScores.score10));
        highscores.Sort();
        //this goes through all of the scores and just checks that the one representing the players score has the most recent name;
        for (int i = 0; i < highscores.Count; i++)
        {
            if (highscores[i].Score == playerSavedScore)
            {
                if (highscores[i].Name != playerSavedName)
                {
                    highscores[i].Name = playerSavedName;
                }
            }
        }
    }
    //old check high scores
    public void CheckScoreAgainstHighScores(int score){
        GetScores();
        for (int i = 0; i < (numberOfDisplayedScores-1); i++)
        {
            Debug.Log("highscore[" + i + "] " + highscores[i].Score);
            Debug.Log("Checking against " + i);
            if (score > highscores[i].Score)
            {
                Debug.Log("stop checking, score is higher than " + i);
                highscores.Remove(highscores[numberOfDisplayedScores - 1]);
                //AskForName();
                return;
            }
        }
        ShowScores();
        Debug.Log("stopped checking");
    }

    public bool CheckIfPlayerGotHighScore(int score)
    {
        GetScores();
        bool higherThanSomething = false;  

        higherThanSomething = highscores.Any(s => s.Score < score);

        //if players score is higher than something on the scoreboard
        if (higherThanSomething)
        {
            Debug.Log("player score is higher than something");
            //if player has a saved score already
            if (playerSavedScore > 0)
            {
                Debug.Log("saved playerscore is higher than 0");
                //and if the players score is higher than one of their previous scores
                if (score > playerSavedScore)
                {
                    Debug.Log("player score is higher than saved player score");

                    //don't ask for name prompt
                    needsNameUpdate = false;

                    //overwrite old score with new
                    for (int i = 0; i < highscores.Count; i++)
                    {
                        if(highscores[i].Name == playerSavedName)
                        {
                            highscores[i].Score = score;
                            playerSavedScore = score;
                            Save();
                        }
                    }                    
                    return true;
                }
                //if it's not higher than one of their previous scores
                else
                {
                    Debug.Log("player score is lower than saved player score");
                    return false;
                }
            }

            //if player doesn't have a high score already
            if (playerSavedScore == 0)
            {
                Debug.Log("saved player score is 0");
                //ask for name prompt
                needsNameUpdate = true;
                return true;
            }
        }

        //if players score isn't higher than anything on the scoreboard
        if (!higherThanSomething)
        {
            return false;
        }

        return false;
    }

    public void UpdateHighScoreList()
    {
        for (int i = 0; i < highscores.Count; i++)
        {
            if (highscores[i].Name == playerSavedName || highscores[i].Name == playerSetName)
            {
                if (currentScore > highscores[i].Score)
                {
                    highscores[i].Score = currentScore;
                }                
            }
        }
    }

    //maybe too UI centric
    private void AskForName(){
        nameEntryboxPrefab.SetActive(true);
        //dont' need below
        for (int i = 0; i < tempList.Count; i++)
        {
            Destroy(tempList[i].gameObject);
        }
        tempList.Clear();
    }

    //this should just add to list etc not show scores
    public void AddNameAndScore(string name){
        //this should only be run once
        playerSetName = name;
        savedScores.playerName = name;
        savedScores.playerScore = currentScore;

        //this is where I need to save new inputted name
        highscores.Add(new HighScore(1, name, currentScore));
        Destroy(nameEntryboxClone);
        ShowScores();
        //Debug.Log("did save");
        Save();
    }

    public void ShowScores(){
        highscores.Sort();
        for (int i = 0; i < (numberOfDisplayedScores -1); i++){
            if (i <= highscores.Count - 1)
            {
                GameObject tmpObj = Instantiate(scorePrefab);
                HighScore tmpScore = highscores[i];
                tmpObj.GetComponent<Score_ScoreObject>().SetScore((i + 1).ToString(), highscores[i].Name, highscores[i].Score.ToString());
                tmpObj.transform.SetParent(scoreGrid);
                tmpObj.transform.GetComponent<RectTransform>().localScale = Vector3.one;
                tempList.Add(tmpObj);
            }
        }
    }

    public int CalculateScore()
    {
        int jellies = characterCols.jelliesCollected;
        float time = _GM.instance.timeTime * 100;
        

        Debug.Log("jellies = " + jellies);
        Debug.Log("time = " + time);
        

        jellyScore = jellies * jellyValue;
        timeScore = (int)(timeValue - (time));
        int score = timeScore + jellyScore;
        if (clothes.activeSelf == true)
        {
            clothesBool = true;
            score += clothesValue;
        }

        currentScore = score;
        Debug.Log("score = " + score);
        return score;
    }
}
