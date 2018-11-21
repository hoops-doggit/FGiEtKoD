using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score_ScoreObject : MonoBehaviour {


    public GameObject rank;
    public GameObject scoreName;
    public GameObject score;

    public void SetScore(string Rank, string Scorename, string score)
    {
        this.rank.GetComponent<Text>().text = Rank;
        this.scoreName.GetComponent<Text>().text = Scorename;
        this.score.GetComponent<Text>().text = score;
    }

}
