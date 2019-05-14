﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DoodleStudio95;

public class PepperShaker : MonoBehaviour {

	public bool gotHit;
	public float speed;
	public bool animating = false;
	private Animator anim;
	private DoodleAnimator ppAnim;
	public GameObject pepperShaker;
	public GameObject pepperPowder;
	private GameObject _pepperPowderClone;
	public Vector3 powderPos;
    private ColourEffect_Propogation _cep;
    private Collider col;
    public GameObject Orange;
    public float orangeOffset;
	// Use this for initialization

	private void Start(){
		anim = pepperShaker.GetComponent<Animator> ();
		ppAnim = pepperPowder.GetComponent<DoodleAnimator> ();
        _cep = GetComponent<ColourEffect_Propogation>();
        col = GetComponent<BoxCollider>();
	}

	private void OnTriggerEnter(Collider other)
	{
        Destroy(col);
        ColourEffect_DS_Static ds = GetComponentInChildren<ColourEffect_DS_Static>();

        //this runs when giant orange hits the pepper
        if(other.gameObject.tag == "orange")
        {
            other.gameObject.GetComponentInParent<Orange_Behaviour>().DoTheThing(gameObject);
        }

        //if the thing that bumps into me is the player
        if (other.gameObject.tag == "player")
        {
            //and if i am orange
            if (_cep.colourEffectText == "orange")
            {
                other.gameObject.GetComponentInParent<CharacterMovement>().GotHit();
                GameObject orange = Instantiate(Orange, gameObject.transform, true);
                orange.transform.parent = null;
                orange.transform.localScale = Vector3.one * 0.5f;
                orange.transform.position = new Vector3(transform.position.x, 0, transform.position.z + orangeOffset);

                Orange_Behaviour ob = orange.GetComponent<Orange_Behaviour>();
                gotHit = true;
                animating = true;
                anim.SetTrigger("jump");
            }

            //and if i am pink
            if (_cep.colourEffectText == "pink")
            {

                string colour = other.gameObject.GetComponentInChildren<BakedAnimator>().currentColour;
                ColourEffect_DS_Static ce = GetComponentInChildren<ColourEffect_DS_Static>();
                ce.ChangeColour(colour);
                pepperPowder.SetActive(true);
                DoPowder();
                gotHit = true;
                animating = true;
                anim.SetTrigger("jump");
                other.gameObject.GetComponentInParent<CharacterMovement>().GotHit();
            }

            else if (_cep.colourEffectText == "green")
            {
                pepperPowder.SetActive(true);
                DoPowder();
                gotHit = true;
                animating = true;
                anim.SetTrigger("jump");
                other.gameObject.GetComponentInParent<CharacterMovement>().GotHitColoured(_cep.colourEffectText);
            }

            else if (_cep.colourEffectText == "yellow")
            {
                pepperPowder.SetActive(true);
                DoPowder();
                gotHit = true;
                animating = true;
                anim.SetTrigger("jump");
                other.gameObject.GetComponentInParent<CharacterMovement>().GotHitColoured(_cep.colourEffectText);
            }

            else if (_cep.colourEffectText == "blue")
            {
                pepperPowder.SetActive(true);
                DoPowder();
                gotHit = true;
                animating = true;
                anim.SetTrigger("jumpslow");
                other.gameObject.GetComponentInParent<CharacterMovement>().GotHitColoured("blue");
            }
        }
    }

	public void DoPowder(){
		StartCoroutine ("PlayPowder");
	}

	IEnumerator PlayPowder(){
		DoodleAnimator ppAnim = pepperPowder.GetComponent<DoodleAnimator>();
		yield return ppAnim.PlayAndPauseAt();
	}


	// Update is called once per frame
	void FixedUpdate () {
		if (gotHit) {
			gameObject.transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z + speed);
		}
	}
}
