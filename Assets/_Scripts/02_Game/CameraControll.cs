using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControll : MonoBehaviour {

    public Transform character;
    private Vector3 _startPos;
    private Vector3 _offset;

	// Use this for initialization
	void Start () {
        _startPos = gameObject.transform.position;
        _offset = _startPos - character.position ;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        gameObject.transform.position = character.position + _offset;
	}
}
