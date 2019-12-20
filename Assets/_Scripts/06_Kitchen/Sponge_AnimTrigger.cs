using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sponge_AnimTrigger : MonoBehaviour {

	

    private void OnCollisionEnter(Collision collision)
    {
        GetComponentInParent<Sponge_Behaviour>().StartSpongeAnimation();
    }
}
