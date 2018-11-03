using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Animations;

public class CharacterJumpScaling : MonoBehaviour {



    public Animator stateMachine;
    public Animator runStateMachine;




    public void StopAnimating()
    {
        stateMachine.speed = 0;
    }

    public void StartRunAnimation()
    {
        runStateMachine.SetTrigger("Run");
    }

    public void StartAnimating()
    {
        stateMachine.speed = 1;
    }

    public void TurnOffBool()
    {
        //stateMachine.SetBool("Jump", false);
    }

}
