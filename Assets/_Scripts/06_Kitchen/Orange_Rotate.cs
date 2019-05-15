using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orange_Rotate : MonoBehaviour {

    public float rotationSpeed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.Rotate(Vector3.right, rotationSpeed);
	}
}
