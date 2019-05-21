using UnityEngine;

public class Sponge_Behaviour : MonoBehaviour {

	public Animator anim;


	void OnCollisionEnter(Collision col){
		anim.SetTrigger ("hit");
	}
}
