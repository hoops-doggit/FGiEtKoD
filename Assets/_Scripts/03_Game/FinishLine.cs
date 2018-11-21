using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour {

    public _GM gm;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "player")
        {

            gm.LevelComplete();
        }
    }
}
