using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FX_LightningSecondarySpawn : MonoBehaviour {

    public GameObject secondarySpark;
    private GameObject secondary;
    public Transform parent;


	public void DoSecondarySpark()
    {
        secondary = Instantiate(secondarySpark, gameObject.transform.position, Quaternion.identity, parent);
        secondary.transform.localPosition = new Vector3(3.29f, 2.1f, 0);
        secondary = Instantiate(secondarySpark, gameObject.transform.position, Quaternion.identity, parent);
        secondary.transform.localPosition = new Vector3(-3.29f, 2.1f, 0);
    }
}
