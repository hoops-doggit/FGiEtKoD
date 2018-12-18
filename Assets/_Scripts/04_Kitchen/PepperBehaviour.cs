using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PepperBehaviour : MonoBehaviour {

	public GameObject parent;

	public void LowerSpeed(){
		parent.GetComponent<PepperShaker> ().speed = parent.GetComponent<PepperShaker>().speed / 2;
	}

	public void FinishedAnimation(){
		Destroy (parent);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
