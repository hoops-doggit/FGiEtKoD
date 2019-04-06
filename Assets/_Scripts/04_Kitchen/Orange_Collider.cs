using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orange_Collider : MonoBehaviour {

    public GameObject parent;

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "orange")
        {
            if (collision.gameObject.tag != "ground")
            {
                Debug.Log("orange collided with: " + collision.gameObject.name);
                //GameObject particlesParent = collision.gameObject;
                parent.GetComponent<Orange_Behaviour>().DoTheThing(collision.gameObject);
            }
        }
    }

}
