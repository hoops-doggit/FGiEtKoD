using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCollisions : MonoBehaviour {

    public bool groundContact;
    public int groundContacts;

    private void Start()
    {
        groundContact = true;
    }

    public void OnCollisionEnter(Collision col)
    {
        Debug.Log("thing");
        if (col.gameObject.tag == "ground")
        {
            groundContact = true;
            groundContacts++;
        }
    }

    public void OnCollisionExit(Collision col)
    {
        if (col.gameObject.tag == "ground")
        {
            groundContact = false;
            groundContacts--;
        }
    }
}
