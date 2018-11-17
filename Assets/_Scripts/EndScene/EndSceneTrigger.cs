using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndSceneTrigger : MonoBehaviour {

    public LightsManager lm;

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponentInParent<CharacterMovement>().EndScene();
        Debug.Log("StartSlowDown");
        lm.EnteringCatwalk();
        //gameObject.SetActive(false);
    }


}
