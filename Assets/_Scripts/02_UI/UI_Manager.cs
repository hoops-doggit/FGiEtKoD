﻿using System.Collections;
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


    public void GotHighScore(int score, int jelliesCollected, int jellyPoints, int timePoints, bool clothed, int clothesPoints)
    {
        gameCanvas.SetActive(false);
        levelEndCanvas.SetActive(true);
        resultsScreen.SetActive(true);
        youGotHighScoreText.SetActive(true);

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


        continueToNameEntryButton.SetActive(true);
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
    }

    public void ShowNameInputScreen()
    {

        resultsScreen.SetActive(false);
        nameEntryHighScoreText.text = Score_ScoreManager.instance.currentScore.ToString() + "!";
        nameInputScreen.SetActive(true);
    }

    public void CommitName()
    {
        Score_ScoreManager.instance.AddNameAndScore(inputField.text);
        nameInputScreen.SetActive(false);
        hallOfFame.SetActive(true);
    }

    public void ShowHallOfFame()
    {
        resultsScreen.SetActive(false);
        Score_ScoreManager.instance.ShowScores();
        hallOfFame.SetActive(true); 
    }

}
