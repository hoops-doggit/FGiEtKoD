using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCollisions : MonoBehaviour {

    public bool groundContact;
    public int groundCount;
    public CharacterMovement cm;
    public GameObject clothes_top;

	public int jelliesCollected;

    private void Start()
    {
        groundContact = true;
        clothes_top.SetActive(false);
    }

    public void OnCollisionEnter(Collision col)
    {
        Debug.Log(col.gameObject.name);
        if (col.gameObject.tag == "ground")
        {
            groundContact = true;
            groundCount++;
        }

        if (col.gameObject.tag == "box")
        {
            cm.Pushback();
        }

        if (col.gameObject.tag == "jellyBean") {
			jelliesCollected++;
		}

        if (col.gameObject.tag == "clothesPile")
        {
            clothes_top.SetActive(true);
            Destroy(col.gameObject.GetComponent<BoxCollider>());
            cm.HitClothesPile();
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
