using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateScript : MonoBehaviour {

    [SerializeField]
    private int gateNumber;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "player")
        {
            Character_HitTracker.instance.ResetHit(gateNumber);
            //reset hit number
            //send analytics data
            Debug.Log("went through gate: " + gateNumber);
            gameObject.SetActive(false);
        }
    }
}
