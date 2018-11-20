using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreManager : MonoBehaviour {

    // Use this for initialization
    private HighScores _hs;

    public Text text;


	void Start () {
        DontDestroyOnLoad(gameObject);
        LoadHighScores();
        text.text = _hs.score.ToString();
	}

    //this is for checking whether current score is new highscore. If it is it saves
    public void SubmitNewPlayerScore(int newScore)
    {
        if (newScore > _hs.score)
        {
            _hs.score = newScore;
            SavePlayerProgress();
            text.text = _hs.score.ToString();
        }        
    }

    //this is for after submitting a high score. Use it to send score to text object
    public int GetHighestPlayerScore()
    {
        return _hs.score;
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
