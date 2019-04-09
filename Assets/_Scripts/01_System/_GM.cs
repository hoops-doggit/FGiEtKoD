using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class _GM : MonoBehaviour {
    public static _GM instance;

	public Transform gummyBearPivot;
	public string sceneName;
	public Text millisecondsElapsed;
	public Text secondsElapsed;
	public Text jelliesCollected;
	public CharacterCollisions characterCol;
    public GameObject GameCanvas;
    public GameObject LevelEndCanvas;
    public GameObject gotHighScoreGroup;
    public GameObject didntGetHighScoreGroup;
	//private float timer;
	public float timeTime = 0f;
    public LightsManager lm;
    public bool catwalk;

    public int numberOfJelliesCollected;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        else if (instance != this)
        {
            Destroy(gameObject);
        }

        int width = 320; // or something else
        int height = 640; // or something else
        bool isFullScreen = false; // should be windowed to run in arbitrary resolution
        int desiredFPS = 60; // or something else

        Screen.SetResolution(width, height, isFullScreen, desiredFPS);
        //DontDestroyOnLoad(gameObject);        
    }

    public void SetTime(){
		timeTime = 0f;
	}

	void Start(){
		SetTime ();
        LevelEndCanvas.SetActive(false);

        if (GameCanvas.activeSelf == false) {
            GameCanvas.SetActive(true); }
	}

    public void LevelComplete(bool booley)
    {
        Time.timeScale = 0.0f;
        if (booley)
        {
            //Player did get a high score so show the results screen with highscore text
            UI_Manager.instance.GotHighScore(Score_ScoreManager.instance.currentScore, numberOfJelliesCollected, Score_ScoreManager.instance.jellyScore, Score_ScoreManager.instance.timeScore);            
        }

        else if (!booley)
        {
            //Player didn't get a high score so just show results screen
            UI_Manager.instance.DidntGetHighScore(Score_ScoreManager.instance.currentScore, numberOfJelliesCollected, Score_ScoreManager.instance.jellyScore, Score_ScoreManager.instance.timeScore);
        }
    }

    
    public void Restart()
    {
        Time.timeScale = 1;
        string currentScene = SceneManager.GetActiveScene().name;
        //SceneManager.LoadScene(sceneName);
        SceneManager.LoadScene(currentScene);
       
        SetTime();
        lm.SetEnvironmentSettings();
        numberOfJelliesCollected = 0;
        Debug.Log(currentScene);
    }

    // Update is called once per frame
    void Update () {
		//resets gb when below the ground a little
		//if (gummyBearPivot.transform.position.y < -0.5f) {
  //          Restart();
		//}
			
		//resets the scene
		if (Input.GetKeyDown(KeyCode.Comma)){
            Restart();
		}

        numberOfJelliesCollected = characterCol.jelliesCollected;
        //updates the jellybeanCounter;
        jelliesCollected.text = numberOfJelliesCollected.ToString();

        if (!catwalk)
        {
            timeTime = timeTime + Time.deltaTime;
            string timeElapsed = Mathf.RoundToInt((float)System.TimeSpan.FromSeconds(timeTime).TotalMilliseconds).ToString();

            if (timeElapsed.Length == 2)
            {
                millisecondsElapsed.text = timeElapsed.Remove(0,1);
                secondsElapsed.text = "0";
            }

            else if (timeElapsed.Length == 3)
            {
                string temp = timeElapsed.Remove(0, 1);
                //temp = temp.Remove();
                millisecondsElapsed.text = temp;
                secondsElapsed.text = "0";
            }

            else if (timeElapsed.Length == 4)
            {
                string temp = timeElapsed.Remove(0, 1);
                temp = temp.Remove(2);
                millisecondsElapsed.text = temp;
                secondsElapsed.text = timeElapsed.Remove(1);
            }

            else if (timeElapsed.Length == 5)
            {
                string temp = timeElapsed.Remove(0, 2);
                temp = temp.Remove(2);
                millisecondsElapsed.text = temp;
                secondsElapsed.text = timeElapsed.Remove(2);
            }
        }        
    }
}
