using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndSceneTrigger : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponentInParent<CharacterMovement>().EndScene();
        Debug.Log("StartSlowDown");
        //gameObject.SetActive(false);
    }


}
