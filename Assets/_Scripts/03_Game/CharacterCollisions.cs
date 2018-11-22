using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCollisions : MonoBehaviour {

    public bool groundContact;
    public int groundCount;
    public CharacterMovement cm;
    public GameObject clothes_top;

    //jelliesCollected gets incrememnted up inside a jellybean script. Not the topmost one.
    //NOTE: Jellybeans are triggers
    public int jelliesCollected;

    private void Start()
    {
        groundContact = false;
        clothes_top.SetActive(false);
    }
    

    public void OnCollisionEnter(Collision col)
    {
        //Debug.Log(col.gameObject.name);
        //Debug.Log(col.gameObject.tag);
        if (col.gameObject.tag == "ground")
        {
            groundContact = true;
            groundCount++;

        }

        if (col.gameObject.tag == "box")
        {
            cm.Pushback();
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
