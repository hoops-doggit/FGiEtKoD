using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour {

    public static SaveManager Instance { set; get; }
    public HighScores state;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        Instance = this;
        Load();

        Debug.Log(SaveHelper.Serialize<HighScores>(state));
    }

    public void Save()
    {
        PlayerPrefs.SetString("save", SaveHelper.Serialize<HighScores>(state));
    }

    //Load the previous score state
    public void Load()
    {
        if (PlayerPrefs.HasKey("save"))
        {
            state = SaveHelper.Deserialize<HighScores>(PlayerPrefs.GetString("save"));
        }

        else
        {
            state = new HighScores();
            Save();
            Debug.Log("no save state found. Creating new one");
        }
    }
}

