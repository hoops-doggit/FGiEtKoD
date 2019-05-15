using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orange_Movement : MonoBehaviour {

    public float speed;

	// Update is called once per frame
	void Update () {
        gameObject.transform.position += Vector3.forward*speed;
	}
}
