using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water_Behaviour : MonoBehaviour {

    public GameObject iceFloor;

    private void OnEnable()
    {
        iceFloor.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "player")
        {
            CharacterMovement cm = other.GetComponentInParent<CharacterMovement>();
            if (cm.slowed||cm.charSpriteOBJ.GetComponent<BakedAnimator>().currentColour == "blue")
            {
                iceFloor.SetActive(true);

            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "player")
        {
            CharacterMovement cm = other.GetComponentInParent<CharacterMovement>();
            if (cm.slowed || cm.charSpriteOBJ.GetComponent<BakedAnimator>().currentColour == "blue")
            {
                iceFloor.SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
