using System.Collections;
using System.Collections.Generic;
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

    public GameObject scorePrefab;
    public Transform scoreGrid;
    //public Transform Canvas;
    public int numberOfDisplayedScores;

    public GameObject nameEntryboxPrefab;
    private GameObject nameEntryboxClone;

    [Header("Score Values")]
    public int jellyValue = 150;
    public int timeValue;

    [Header("Scores Saved")]
    public int jellyScore = 150;
    public int timeScore;
    public int currentScore;

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
        //GetScores();
        //ShowScores();
    }

    public void Save(){
        //this is setting the values in saved score data before serialising into the playerpreffs
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

        PlayerPrefs.SetString("save", Score_Serializer.Serialize<Score_SavedScoreData>(savedScores));
    }
    

    public void Load()
    {
        if(PlayerPrefs.HasKey("save")){
            savedScores = Score_Serializer.Deserialize<Score_SavedScoreData>(PlayerPrefs.GetString("save"));
            Debug.Log("Loading and savedScores does exist");
        }

        else{
            savedScores = new Score_SavedScoreData();
            Save();
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
        highscores.Add(new HighScore(10, savedScores.name3, savedScores.score10));
        highscores.Sort();
    }

    public void CheckScoreAgainstHighScores(int score){
        GetScores();
        for (int i = 0; i < (numberOfDisplayedScores-1); i++)
        {
            Debug.Log("Checking against " + i);
            if (score > highscores[i].Score)
            {
                Debug.Log("stop checking, score is higher than " + i);
                highscores.Remove(highscores[numberOfDisplayedScores - 1]);
                AskForName();
                return;
            }
        }
        ShowScores();
        Debug.Log("stopped checking");
    }

    public bool CheckIfPlayerGotHighScore(int score)
    {
        GetScores();
        for (int i = 0; i < (numberOfDisplayedScores); i++)
        {
            Debug.Log("Checking against " + i);
            if (score > highscores[i].Score)
            {
                Debug.Log("stop checking, score is higher than " + i);
                highscores.Remove(highscores[numberOfDisplayedScores - 1]);
                currentScore = score;
                AskForName();
                return true;
            }
        }
        return false;
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
        highscores.Add(new HighScore(1, name, currentScore));
        highscores.Sort();
        Destroy(nameEntryboxClone);
        ShowScores();
        Debug.Log("did save");
        Save();
    }

    public void ShowScores(){
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
        int jellies = _GM.instance.gummyBearPivot.GetComponent<CharacterCollisions>().jelliesCollected;
        float time = _GM.instance.timeTime * 100;

        Debug.Log("jellies = " + jellies);
        Debug.Log("time = " + time);
        

        jellyScore = jellies * jellyValue;
        timeScore = (int)(timeValue - (time));
        int score = timeScore + jellyScore;
        currentScore = score;
        Debug.Log("score = " + score);
        return score;
    }
}
