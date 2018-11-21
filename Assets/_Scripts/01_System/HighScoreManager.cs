using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreManager : MonoBehaviour {

    // Use this for initialization
    private HighScore _hs;


    public Text name0;
    public Text score0;
    public Text name01;
    public Text score01;
    public Text name02;
    public Text score02;
    public Text name03;
    public Text score03;
    public Text name04;
    public Text score04;

    private int score00int;
    private int score01int;
    private int score02int;
    private int score03int;
    private int score04int;

    private string name00name;
    private string name01name;
    private string name02name;
    private string name03name;
    private string name04name;





    private int[] scores ={   };

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
        /*if (newScore > _hs.score)
        {
            _hs.score = newScore;
            SavePlayerProgress();
            //text.text = _hs.score.ToString();
        }*/
        
        for(int i = 0; i < scores.Length; i++)
        {
            if (newScore > scores[0]) 
            {
                //function(i, newscore)
            }
        }
    }

    private bool CheckIfScoreIsGreater(int i, int newscore)
    {
        return true;
    }

#region temp
    private void UpdateScore00(int newscore, string name)
    {
        score04int = score03int;
        name04name = name03name;
        score03int = score02int;
        name03name = name02name;
        score02int = score01int;
        name02name = name01name;
        score01int = score00int;
        name01name = name00name;
        score00int = newscore;
        name00name = name;
    }

    private void UpdateScore01(int newscore, string name)
    {
        score04int = score03int;
        name04name = name03name;
        score03int = score02int;
        name03name = name02name;
        score02int = score01int;
        name02name = name01name;
        score01int = newscore;
        name01name = name;
    }

    private void UpdateScore02(int newscore, string name)
    {
        score04int = score03int;
        name04name = name03name;
        score03int = score02int;
        name03name = name02name;
        score02int = newscore;
        name02name = name;
    }

    private void UpdateScore03(int newscore, string name)
    {
        score04int = score03int;
        name04name = name03name;
        score03int = newscore;
        name03name = name;
    }

    private void UpdateScore04(int newscore, string name)
    {
        score04int = newscore;
        name04name = name;
    }
    #endregion



    //this is for after submitting a high score. Use it to send score to text object
    public int GetHighestPlayerScore()
    {
        return _hs.score01;
    }

    public void UpdateScoreOnScreen()
    {
        //text.text = _hs.score.ToString();
    }
	
	private void LoadHighScores()
    {
        //sets _hs from the player prefs
        //_hs = new HighScore();
        if (PlayerPrefs.HasKey("score01"))
        {
            _hs.score01 = PlayerPrefs.GetInt("score01");
        }
        if (PlayerPrefs.HasKey("score02"))
        {
            _hs.score02 = PlayerPrefs.GetInt("score02");
        }
        if (PlayerPrefs.HasKey("score03"))
        {
            _hs.score03 = PlayerPrefs.GetInt("score03");
        }
        if (PlayerPrefs.HasKey("score04"))
        {
            _hs.score04 = PlayerPrefs.GetInt("score04");
        }
        if (PlayerPrefs.HasKey("score00"))
        {
            _hs.score00 = PlayerPrefs.GetInt("score00");
        }
    }

    public void DeleteSavedData()
    {
        PlayerPrefs.DeleteAll();
    }

    private void SavePlayerProgress()
    {
        PlayerPrefs.SetInt("score01", _hs.score01);
        PlayerPrefs.SetInt("score02", _hs.score02);
        PlayerPrefs.SetInt("score03", _hs.score03);
        PlayerPrefs.SetInt("score04", _hs.score04);
        PlayerPrefs.SetInt("score00", _hs.score00);
    }

}
