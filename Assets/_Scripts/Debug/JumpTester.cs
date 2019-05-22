using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpTester : MonoBehaviour {

    public CharacterMovement cm;
    public bool fast;

    private void Update()
    {
        cm.moveSpeed = cm.maxSpeed;
       
        if (fast)
        {
            cm.FastInitial();
            cm.Jump();
        }
        else
        {
            cm.Jump();
        }
    }
}
