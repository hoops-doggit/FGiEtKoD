using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score_ScoreManager : MonoBehaviour {

    public static Score_ScoreManager instance;
    public Score_SavedScoreData savedScores;

    public List<HighScore> highscores = new List<HighScore>();

    public GameObject scorePrefab;
    public Transform scoreGrid;
    public Transform Canvas;
    public int numberOfDisplayedScores;

    public GameObject nameEntryboxPrefab;
    private GameObject nameEntryboxClone;

    public int currentScore;

    private void Awake()
    {
        instance = this;
    }

    // Use this for initialization
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        Load();
        //GetScores();
        //ShowScores();
    }

    public void Save(){
        PlayerPrefs.SetString("save", Score_Serializer.Serialize<Score_SavedScoreData>(savedScores));
    }
    

    public void Load()
    {
        if(PlayerPrefs.HasKey("save")){
            savedScores = Score_Serializer.Deserialize<Score_SavedScoreData>(PlayerPrefs.GetString("save"));
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

    public void CheckScore(int score){
        GetScores();
        for (int i = 0; i < numberOfDisplayedScores; i++)
        {
            Debug.Log("Checking against " + i);
            if (score > highscores[i].Score)
            {
                Debug.Log("stop checking, score is higher than " + i);
                highscores.Remove(highscores[numberOfDisplayedScores - 1]);
                currentScore = score;
                AskForName();
                return;
            }
        }

        ShowScores();
        Debug.Log("stopped checking");
    }

    //maybe too UI centric
    private void AskForName(){
        nameEntryboxClone = Instantiate(nameEntryboxPrefab) as GameObject;
        nameEntryboxClone.transform.SetParent(Canvas);
        nameEntryboxClone.GetComponent<RectTransform>().position = Vector3.one;
        nameEntryboxClone.GetComponent<RectTransform>().position = Vector3.one;
        nameEntryboxClone.GetComponent<RectTransform>().position = Vector3.one;

    }

    public void AddNameAndScore(string name){
        highscores.Add(new HighScore(1, name, currentScore));
        highscores.Sort();
        Destroy(nameEntryboxClone);
        ShowScores();
        Save();
    }

    private void ShowScores(){
        for (int i = 0; i < numberOfDisplayedScores; i++){
            if (i <= highscores.Count - 1)
            {
                GameObject tmpObj = Instantiate(scorePrefab);
                HighScore tmpScore = highscores[i];
                tmpObj.GetComponent<Score_ScoreObject>().SetScore((i + 1).ToString(), highscores[i].Name, highscores[i].Score.ToString());
                tmpObj.transform.SetParent(scoreGrid);
            }
        }
    }
}
