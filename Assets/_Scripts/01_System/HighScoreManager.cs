using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreManager : MonoBehaviour {

    // Use this for initialization
    private HighScores _hs;

    public Text name01;
    public Text score01;
    public Text name02;
    public Text score02;
    public Text name03;
    public Text score03;
    public Text name04;
    public Text score04;
    public Text name05;
    public Text score05;


	void Start () {
        DontDestroyOnLoad(gameObject);
        LoadHighScores();
        //text.text = _hs.score.ToString();
	}

    //this is for checking whether current score is new highscore. If it is it saves
    public void SubmitNewPlayerScore(int newScore)
    {
        //this needs to now go through all of the scores
        //check if it's higher than any of the scores
        //if it is then it should delete the lowest score then move all lower scores down
        //then replace the empty slot with it's score
        if (newScore > _hs.score)
        {
            _hs.score = newScore;
            SavePlayerProgress();
            //text.text = _hs.score.ToString();
        }        
    }

    //this is for after submitting a high score. Use it to send score to text object
    public int GetHighestPlayerScore()
    {
        return _hs.score;
    }

    public void UpdateScoreOnScreen()
    {
        //text.text = _hs.score.ToString();
    }
	
	private void LoadHighScores()
    {
        _hs = new HighScores();
        if (PlayerPrefs.HasKey("score"))
        {
            _hs.score = PlayerPrefs.GetInt("score");
        }
    }

    public void DeleteSavedData()
    {
        PlayerPrefs.DeleteAll();
    }

    private void SavePlayerProgress()
    {
        PlayerPrefs.SetInt("score", _hs.score);
    }

}
