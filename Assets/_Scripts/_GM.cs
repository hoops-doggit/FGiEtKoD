using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class _GM : MonoBehaviour {

	public Transform gummyBearPivot;
	public string sceneName;






	// Use this for initialization
	void Start () {
		//sceneName = SceneManager.GetActiveScene ().ToString();
	}
	
	// Update is called once per frame
	void Update () {
		if (gummyBearPivot.transform.position.y < -0.5f) {
			SceneManager.LoadScene (sceneName);
		}
	}
}
