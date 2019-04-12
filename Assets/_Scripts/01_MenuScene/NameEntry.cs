using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NameEntry : MonoBehaviour {

    public GameObject nameEntry;
    public Text nameEntryBox;

    private Score_SavedScoreData savedScores;


    public void TurnOn()
    {
        //Score_ScoreManager.instance.Load();
        nameEntry.SetActive(true);
    }

    public void TurnOff()
    {
        nameEntry.SetActive(false);
    }


    public void CommitNameFromMenu()
    {
        if (PlayerPrefs.HasKey("save"))
        {
            savedScores = Score_Serializer.Deserialize<Score_SavedScoreData>(PlayerPrefs.GetString("save"));
            savedScores.playerName = nameEntryBox.text;
            PlayerPrefs.SetString("save", Score_Serializer.Serialize<Score_SavedScoreData>(savedScores));
            Debug.Log("i think i loaded and saved");
        }

        else
        {
            savedScores = new Score_SavedScoreData();
            savedScores.playerName = nameEntryBox.text;
            PlayerPrefs.SetString("save", Score_Serializer.Serialize<Score_SavedScoreData>(savedScores));
            Debug.Log("i think i saved");
        }

        TurnOff();
    }
}
