using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DoodleStudio95;

public class TomatoSplat : MonoBehaviour {

	public DoodleAnimator anim;
	public Transform splatHolder;
	public GameObject splat;
	private GameObject splatClone;
	public DoodleAnimationFile splatAnimation;




	void OnTriggerEnter(Collider other)
	{
		other.gameObject.GetComponentInParent<CharacterMovement> ().GotHit();
		gameObject.GetComponent<SpriteRenderer>().enabled = false;
		DoSplat ();
	}
		

	IEnumerator PlaySplat() {
		splatClone = Instantiate (splat, splatHolder.transform);
		splatClone.transform.SetParent(splatHolder);
		DoodleAnimator animator = splatClone.GetComponent<DoodleAnimator>();
		yield return animator.PlayAndPauseAt();
		animator.Stop();
		Destroy (splatClone);
		Destroy (gameObject);
		StopCoroutine ("PlaySplat");
	}

	public void DoSplat() {
		StartCoroutine(PlaySplat());
	}

}
