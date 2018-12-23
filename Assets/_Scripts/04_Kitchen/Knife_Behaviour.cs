using System.Collections;
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

        Animator anim = GetComponentInChildren<Animator>();

        anim.speed = 0f;

        anim.Play("Knife_Big", 0, animationOffset);

        if (GetComponentInChildren<ColourEffect_Propogation>().colourEffectText == "blue")
        {
            anim.speed = slowAnimationSpeed;
        }
        else
        {
            anim.speed = animationSpeed;
        }
    

        //AnimationClip

        //anim["Knife_Big"].time =
        //animanim["Knife_Big"].time = animationOffset / animanim["Knife_Big"].length;

        //transform.eulerAngles = new Vector3(0, 0, startRot);

        if (transform.position.x > 1)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
            transform.localScale = new Vector3(1, 1, -1);
            SpriteRenderer sr = GetComponentInChildren<SpriteRenderer>();
            sr.flipX = true;
            downRot = downRot * -1;

        }
        _goingDown = true;
        waitTime = 0;
        waitMax = 16;
		
	}

    private void Update()
    {
        //Animator anim = GetComponentInChildren<Animator>();

        //anim.speed = animationSpeed;
    }

    //// Update is called once per frame
    //void FixedUpdate () {


    //       if (_goingDown && !wait)
    //       {
    //           KnifeDown();
    //       }

    //       else if (!_goingDown && !wait)
    //       {
    //           KnifeUp();
    //       }

    //       if (wait)
    //       {
    //           waitTime++;
    //           if (waitTime >= waitMax)
    //           {
    //               waitTime = 0;
    //               _goingDown = true;
    //               wait = false;
    //           }
    //       }

    //   }
}
