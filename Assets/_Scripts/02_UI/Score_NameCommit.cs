using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score_NameCommit : MonoBehaviour {

    public InputField nameInputField;

    public void CommitNameToHighScore(){
        Score_ScoreManager.instance.AddNameAndScore(nameInputField.text);
    }
}
