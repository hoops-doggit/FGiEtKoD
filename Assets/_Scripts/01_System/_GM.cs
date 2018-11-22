using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class _GM : MonoBehaviour {
    public static _GM instance = null;

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
        DontDestroyOnLoad(gameObject);        
    }

    public void SetTime(){
		//Debug.Log ("Did Time");
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
            UI_Manager.instance.GotHighScore(Score_ScoreManager.instance.currentScore, characterCol.jelliesCollected, Score_ScoreManager.instance.jellyScore, Score_ScoreManager.instance.timeScore);            
        }

        else if (!booley)
        {
            //Player didn't get a high score so just show results screen
            UI_Manager.instance.DidntGetHighScore(Score_ScoreManager.instance.currentScore, characterCol.jelliesCollected, Score_ScoreManager.instance.jellyScore, Score_ScoreManager.instance.timeScore);
        }
    }

    
    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(sceneName);
        SetTime();
        lm.SetEnvironmentSettings();
    }

    // Update is called once per frame
    void Update () {
		//resets gb when below the ground a little
		if (gummyBearPivot.transform.position.y < -0.5f) {
            Restart();
		}
			
		//resets the scene
		if (Input.GetKeyDown(KeyCode.R)){
            Restart();
		}

		//updates the jellybeanCounter;
		jelliesCollected.text = characterCol.jelliesCollected.ToString();


		timeTime = timeTime + Time.deltaTime;
		//float currentTime = Time.

		millisecondsElapsed.text = Mathf.RoundToInt((float)System.TimeSpan.FromSeconds(timeTime).TotalMilliseconds).ToString();
		secondsElapsed.text = Mathf.RoundToInt((float)System.TimeSpan.FromSeconds(timeTime).TotalSeconds).ToString();

		//Debug.Log (timer.Milliseconds ());
	}
}
