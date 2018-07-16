using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jellybean_Behaviour : MonoBehaviour {

    public float rotaionSpeed;
    public Vector3 rotate;


    private void OnTriggerEnter(Collider other)
    {
        Destroy(this);
    }

    // Update is called once per frame
    void Update () {
        gameObject.transform.Rotate(rotate, 5f);
	}
}
