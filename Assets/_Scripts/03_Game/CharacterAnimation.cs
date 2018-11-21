using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DoodleStudio95;

public class CharacterAnimation : MonoBehaviour {

	public DoodleAnimator anim;
    public bool coveredInTomato;

	public void Frame01(){
		Debug.Log ("Play frame 01");
		anim.GoToAndPause (1);

	}

	public void Frame02(){
		Debug.Log ("Play frame 02");
		anim.GoToAndPause (2);
	}

}
