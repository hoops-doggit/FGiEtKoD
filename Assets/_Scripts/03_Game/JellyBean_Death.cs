using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyBean_Death : MonoBehaviour {

	public Animator anim;

	void start(){
		anim = gameObject.GetComponent<Animator> ();
	}
		
	public void PlayAnimation(){
		anim.SetTrigger ("Touched");
	}

	public void DestroyJB(){
		Destroy (this.gameObject);
	}
}
