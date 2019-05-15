using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yellow_Pepper : MonoBehaviour {

    public GameObject lightningCollider;
    private GameObject lightningClone;
    public float lightningZOffset;

    public void DoYellow()
    {
        Vector3 pos = new Vector3 (0, 0, gameObject.transform.position.z + lightningZOffset);
        lightningClone = Instantiate(lightningCollider, pos, Quaternion.identity);
        lightningClone.transform.parent = null;
        lightningClone.transform.position = pos;
    }

    
}
