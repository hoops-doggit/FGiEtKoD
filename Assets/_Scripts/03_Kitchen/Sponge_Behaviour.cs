using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sponge_Behaviour : MonoBehaviour {

	public Animator anim;


	void OnCollisionEnter(Collision col){
		anim.SetTrigger ("hit");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
