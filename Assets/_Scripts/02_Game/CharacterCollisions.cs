using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCollisions : MonoBehaviour {

    public bool groundContact;
    public int groundCount;

	public int jelliesCollected;

    private void Start()
    {
        groundContact = true;
    }

    public void OnCollisionEnter(Collision col)
    {
        Debug.Log(col.gameObject.name);
        if (col.gameObject.tag == "ground")
        {
            groundContact = true;
            groundCount++;
        }

		if (col.gameObject.tag == "jellyBean") {
			jelliesCollected++;
		}
    }

    public void OnCollisionExit(Collision col)
    {
        if (col.gameObject.tag == "ground")
        {
            groundContact = false;
            groundCount--;
        }
    }
}
