using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife_Butter : MonoBehaviour {

    private GameObject go;
	// Use this for initialization


	void OnEnable () {
        go = gameObject;
		if (go.transform.position.x > 1)
        {
            go.transform.localScale = new Vector3(go.transform.localScale.x * -1, go.transform.localScale.y, go.transform.localScale.z);
        }
	}
	

}
