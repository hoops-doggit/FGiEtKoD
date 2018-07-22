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
	//private float timer;
	public float timeTime = 0f;




	void OnGUI() {
		/*int minutes = Mathf.FloorToInt(timer / 60F);
		int seconds = Mathf.FloorToInt(timer - minutes * 60);
		int milliseconds = Mathf.FloorToInt (timer - seconds - minutes * 60);
		string niceTime = string.Format("{0:0}:{1:00}:{2}", minutes, seconds, milliseconds);*/

		//int fractions = 100;   // for hundredths of sec
		//int timerSec  = Mathf.RoundToInt(timer);
		//int splitSeconds = Mathf.RoundToInt((timer - timerSec) * fractions);
		//string niceTime = string.Format ("{0:00}:{0:00}", timerSec, splitSeconds);

		//GUI.Label(new Rect(10,10,250,100), niceTime);

		//timeRemaining.text = niceTime;
	}

	public void SetTime(){
		//Debug.Log ("Did Time");
		timeTime = 0f;
	}

	void Start(){
		SetTime ();
	}

	
	// Update is called once per frame
	void Update () {
		if (gummyBearPivot.transform.position.y < -0.5f) {
			SceneManager.LoadScene (sceneName);
			SetTime ();
		}

		if (Input.GetKeyDown(KeyCode.R)){
			SceneManager.LoadScene(sceneName);
			SetTime ();
		}


		//timeTime = timeTime + Time.deltaTime;


		timeTime = timeTime + Time.deltaTime;
		//float currentTime = Time.

		millisecondsElapsed.text = Mathf.RoundToInt((float)System.TimeSpan.FromSeconds(timeTime).TotalMilliseconds).ToString();
		secondsElapsed.text = Mathf.RoundToInt((float)System.TimeSpan.FromSeconds(timeTime).TotalSeconds).ToString();

		//Debug.Log (timer.Milliseconds ());
	}
}
