﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DoodleStudio95;

public class Jellybean_Behaviour : MonoBehaviour {

    public float rotaionSpeed;
    public Vector3 rotate;
    public GameObject parent;
    public float sizeIncrease;
	public float scaleMax;


    private bool gotTouched;

    private void OnTriggerEnter(Collider other)
	{
		
		other.gameObject.GetComponentInParent<CharacterMovement> ().PlayBurst();
		other.gameObject.GetComponent<CharacterCollisions> ().jelliesCollected++;
		parent.GetComponent<JellyBean_Death> ().PlayAnimation ();
	}
		
}
