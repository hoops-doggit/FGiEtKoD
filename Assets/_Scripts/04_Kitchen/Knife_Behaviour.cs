﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife_Behaviour : MonoBehaviour {

    public float knifeDownSpeed;
    public float knifeUpSpeed;
    public float knifePosition;
    public float upRot;
    public float downRot;
    public float startRot;
    private bool wait;
    private int waitTime;
    private int waitMax;

    private float _currentRot;
    public bool _goingDown;

    public float animationOffset;
    public float animationSpeed;
    public float slowAnimationSpeed;

    [SerializeField]
    private Animator knife;
    [SerializeField]
    private Animator knifeShadow;

    

    public void KnifeDown()
    {
        knifePosition = knifePosition + knifeDownSpeed;
        transform.rotation = Quaternion.Euler(0,0, Mathf.Lerp(upRot, downRot, knifePosition ));
        if (knifePosition > 1)
        {
            knifePosition = 0;
            _goingDown = false;
        }
    }

    public void KnifeUp()
    {
        knifePosition = knifePosition + knifeUpSpeed;
        transform.rotation = Quaternion.Euler(0, 0, Mathf.Lerp(downRot, upRot, knifePosition));
        if (knifePosition > 1)
        {
            knifePosition = 0;
            wait = true;
            
        }
    }

    public void StartColliderToggle()
    {
        StartCoroutine("ToggleCollider");
    }

    IEnumerator ToggleCollider()
    {
        var thing = GetComponentInChildren<BoxCollider>();
        thing.enabled = false;
        yield return new WaitForSeconds(1f);
        thing.enabled = true;
    }


    // Use this for initialization
    void Start () {
        //knifePosition = startRot;

        knife.speed = 0f;
        knife.Play("Knife_Big", 0, animationOffset);
        if (knifeShadow != null)
        {
            knifeShadow.speed = 0f;
            knifeShadow.Play("Knife_Shadow", 0, animationOffset);
        }   

        if (GetComponentInChildren<ColourEffect_Propogation_Knife>().colourEffectText == "blue")
        {
            knife.speed = slowAnimationSpeed;
            if (knifeShadow != null)
            {
                knifeShadow.speed = slowAnimationSpeed;
            }
        }
        else
        {
            knife.speed = animationSpeed;
            if (knifeShadow != null)
            {
                knifeShadow.speed = animationSpeed;
            }
        }


        //turns knife if it's on the right side of the track;
        if (transform.position.x > 1)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
            transform.localScale = new Vector3(1, 1, -1);
            SpriteRenderer sr = GetComponentInChildren<SpriteRenderer>();
            sr.flipX = true;
            downRot = downRot * -1;

        }
		
	}

    public void CheckWhichColourIAm(){
        if (GetComponentInChildren<ColourEffect_Propogation_Knife>().colourEffectText == "blue")
        {
            knife.speed = slowAnimationSpeed;
            if (knifeShadow != null)
            {
                knifeShadow.speed = slowAnimationSpeed;
            }

        }
        else
        {
            knife.speed = animationSpeed;
            if (knifeShadow != null)
            {
                knifeShadow.speed = animationSpeed;
            }
        }
    }

    private void Update()
    {
        //Animator anim = GetComponentInChildren<Animator>();

        //anim.speed = animationSpeed;
    }
}
