using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour {


    private void OnTriggerEnter(Collider other)
    {

        //this is returning Null????
        _GM.instance.LevelComplete(Score_ScoreManager.instance.CheckIfPlayerGotHighScore(Score_ScoreManager.instance.CalculateScore()));

        //if (other.tag == "player")
        //{
        //    //i need to calculate the players score and put it into the check;
        //    _GM.instance.LevelComplete(Score_ScoreManager.instance.CheckIfPlayerGotHighScore(Score_ScoreManager.instance.CalculateScore()));
        //}
    }
}
