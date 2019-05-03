using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour {
    public static UI_Manager instance = null;

    public GameObject gameCanvas;
    public GameObject levelEndCanvas;
    public GameObject resultsScreen;
    public GameObject youGotHighScoreText;
    public Text highScoreText;
    public Text nameEntryHighScoreText;
    public Text time;
    public Text pointsFromTime;
    public Text numberOfJelliesCollected;
    public Text pointsFromJellies;
    public Text pointsFromClothes;
    public Text clothesText;
    public GameObject continueToNameEntryButton;
    [SerializeField]
    private GameObject continueToHighScores;
    public GameObject viewHighScoresButton;
    public GameObject mainMenuButton;
    public GameObject playAgainButton;

    public GameObject nameInputScreen;
    public InputField inputField;

    public GameObject hallOfFame;


    private void Awake()
    {
        if (instance == null) { instance = this; }
        else if (instance != this) { Destroy(gameObject); }
    }

    private void Start()
    {
       
        TurnOffAllButtons();
        TurnOffAllScreens();
        gameCanvas.SetActive(true);
    }

    private void TurnOffAllButtons()
    {
        continueToNameEntryButton.SetActive(false);
        viewHighScoresButton.SetActive(false);
        mainMenuButton.SetActive(false);
        playAgainButton.SetActive(false);
        continueToHighScores.SetActive(false);

    }

    public void TurnOffAllScreens()
    {
        gameCanvas.SetActive(false);
        levelEndCanvas.SetActive(false);
        resultsScreen.SetActive(false);
        youGotHighScoreText.SetActive(false);
        nameInputScreen.SetActive(false);
        hallOfFame.SetActive(false);
    }


    public void GotHighScore(int score, int jelliesCollected, int jellyPoints, int timePoints, bool clothed, int clothesPoints, bool needsNameEntry)
    {
        gameCanvas.SetActive(false);
        levelEndCanvas.SetActive(true);
        resultsScreen.SetActive(true);
        

        //setting all text fields
        highScoreText.text = score.ToString() + "!";
        pointsFromJellies.text = jellyPoints.ToString();
        time.text = _GM.instance.secondsElapsed.text;
        pointsFromTime.text = timePoints.ToString();
        if (clothed)
        {
            clothesText.text = "yes!";
            pointsFromClothes.text = clothesPoints.ToString();
        }

        if (!clothed)
        {
            clothesText.text = "X";
            pointsFromClothes.text = "0";
        }
        numberOfJelliesCollected.text = jelliesCollected.ToString();

        if (needsNameEntry)
        {
            continueToNameEntryButton.SetActive(true);
            youGotHighScoreText.SetActive(true);
        }

        if (!needsNameEntry)
        {
            continueToHighScores.SetActive(true);
        }
        
        //assumes all buttons are turned off;
    }

    public void DidntGetHighScore(int score, int jelliesCollected, int jellyPoints, int timePoints, bool clothed, int clothesPoints)
    {
        gameCanvas.SetActive(false);
        levelEndCanvas.SetActive(true);
        resultsScreen.SetActive(true);

        //setting all text fields
        highScoreText.text = score.ToString();
        numberOfJelliesCollected.text = jelliesCollected.ToString();
        pointsFromJellies.text = jellyPoints.ToString();
        time.text = _GM.instance.secondsElapsed.text;
        pointsFromTime.text = timePoints.ToString();
        if (clothed)
        {
            clothesText.text = "yes!";
            pointsFromClothes.text = clothesPoints.ToString();
        }

        if (!clothed)
        {
            clothesText.text = "X";
            pointsFromClothes.text = "0";
        }
        //mainMenuButton.SetActive(true);
        viewHighScoresButton.SetActive(true);
        playAgainButton.SetActive(true);
        mainMenuButton.SetActive(true);
    }

    public void ShowNameInputScreen()
    {
        //this is the only time you should be asked to input your name before going to the score screen
        if(Score_ScoreManager.instance.playerSavedScore == 0)
        {
            //turn off results screen
            resultsScreen.SetActive(false);

            //update score text on name input screen (don't need this on name entry screen)
            //nameEntryHighScoreText.text = Score_ScoreManager.instance.currentScore.ToString() + "!";

            //turn on name input screen
            Debug.Log("tried to load name input screen");
            nameInputScreen.SetActive(true);
        }

        else
        {
            Score_ScoreManager.instance.UpdateHighScoreList();
            ShowHallOfFame();
        }
        
    }

    public void CommitName()
    {
        Score_ScoreManager.instance.playerSetName = inputField.text;
        Score_ScoreManager.instance.AddNameAndScore(inputField.text);
        nameInputScreen.SetActive(false);
        hallOfFame.SetActive(true);
    }

    public void ShowHallOfFame()
    {
        resultsScreen.SetActive(false);
        //update scores with updated scores
        Score_ScoreManager.instance.Load();
        Score_ScoreManager.instance.ShowScores();
        mainMenuButton.SetActive(true);
        
        hallOfFame.SetActive(true); 
    }

}
