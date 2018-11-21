using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public class SaveManager : MonoBehaviour {

//    public static SaveManager Instance { set; get; }
//    public HighScore state;

//    private void Awake()
//    {
//        DontDestroyOnLoad(gameObject);
//        Instance = this;
//        Load();

//        Debug.Log(SaveHelper.Serialize<HighScore>(state));
//    }

//    public void Save()
//    {
//        PlayerPrefs.SetString("save", SaveHelper.Serialize<HighScore>(state));
//    }

//    //Load the previous score state
//    public void Load()
//    {
//        if (PlayerPrefs.HasKey("save"))
//        {
//            state = SaveHelper.Deserialize<HighScore>(PlayerPrefs.GetString("save"));
//        }

//        else
//        {
//            state = new HighScore();
//            Save();
//            Debug.Log("no save state found. Creating new one");
//        }
//    }
//}

