﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DoodleStudio95;

public class TomatoSplat : MonoBehaviour {

	public DoodleAnimator anim;
	public Transform splatHolder;
	public GameObject splat;
	private GameObject splatClone;
	public DoodleAnimationFile splatAnimation;
    public GameObject guts;
    private GameObject gutsClone;


    void OnTriggerEnter(Collider other)
	{
		other.gameObject.GetComponentInParent<CharacterMovement> ().GotHit();
		gameObject.GetComponent<SpriteRenderer>().enabled = false;
		DoSplat ();
	}

    public void DoSplat() {
		StartCoroutine(PlaySequence());
	}	

	IEnumerator PlaySplat() {
        Vector3 gutsPos = new Vector3(transform.position.x, transform.position.y - 0.940f, transform.position.z + 1.53f);
        splatClone = Instantiate (splat, splatHolder.transform);
		splatClone.transform.SetParent(splatHolder);
        gutsClone = Instantiate(guts, gutsPos, Quaternion.identity, gameObject.transform);
		DoodleAnimator animator = splatClone.GetComponent<DoodleAnimator>();
		yield return animator.PlayAndPauseAt();
		animator.Stop();
		Destroy (splatClone);
		Destroy (gameObject);
		StopCoroutine ("PlaySplat");
	}

    public IEnumerator PlaySequence()
    {
        splat.SetActive(true);
        DoodleAnimator animator = splat.GetComponent<DoodleAnimator>();
        yield return animator.PlayAndPauseAt(0, -1);
        animator.Stop();
        splat.SetActive(false);
        StopCoroutine("PlaySequence");
    }



}
