using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Swim : MonoBehaviour {
    


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.localPosition.y <= -7.9f){
            transform.localPosition = new Vector3(transform.localPosition.x, -8f, transform.localPosition.z);
        }
	}
}
