using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PepperShaker : MonoBehaviour {

	public bool gotHit;
	public float speed;
	public bool animating = false;
	public Animator anim;
	// Use this for initialization


	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "player") {
			
			gotHit = true;
			animating = true;
			//anim.Play ("PepperJump");
			anim.SetTrigger("jump");
			other.gameObject.GetComponentInParent<CharacterMovement> ().GotHit();
			Debug.Log ("pepper hit player");
		}

	}


	// Update is called once per frame
	void FixedUpdate () {
		if (gotHit) {
			gameObject.transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z + speed);
		}
	}
}
