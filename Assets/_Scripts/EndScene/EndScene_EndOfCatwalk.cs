using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScene_EndOfCatwalk : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponentInParent<CharacterMovement>().EndScene_EndOfCatWalk();
        Destroy(gameObject);
    }
}
