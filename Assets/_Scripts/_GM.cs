using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class _GM : MonoBehaviour {

	public Transform gummyBearPivot;
	public string sceneName;
	public Text millisecondsElapsed;
	public Text secondsElapsed;
	public Text jelliesCollected;
	public CharacterCollisions characterCol;
    public GameObject GameCanvas;
    public GameObject LevelEndCanvas;
	//private float timer;
	public float timeTime = 0f;


	public void SetTime(){
		//Debug.Log ("Did Time");
		timeTime = 0f;
	}

	void Start(){
		SetTime ();
        LevelEndCanvas.SetActive(false);
	}

    public void LevelComplete()
    {
        Time.timeScale = 0.0f;
        GameCanvas.SetActive(false);
        LevelEndCanvas.SetActive(true);
    }

    
    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(sceneName);
        SetTime();
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
