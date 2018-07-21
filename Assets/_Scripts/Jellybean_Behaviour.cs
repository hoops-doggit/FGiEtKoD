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
		gotTouched = true;
	}



    void Update () {
        //parent.transform.Rotate(rotate, rotaionSpeed);


        if (gotTouched)
        {
            parent.transform.localScale = new Vector3(parent.transform.localScale.x + sizeIncrease, parent.transform.localScale.y + sizeIncrease, parent.transform.localScale.z + sizeIncrease);


            if (parent.transform.localScale.x > scaleMax)
            {
				Destroy(parent);
            }
        }
	}
}
