using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class _DegugText : MonoBehaviour {

    public CharacterMovement gbgo;

    public Text groundContact;
    public Text trueGroundContact;


    private void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate () {

		if (gbgo._groundContact == true)
        {
            groundContact.text = "GroundContact: yes";
        }
        else
        {
            groundContact.text = "GroundContact: no";
        }

        if(gbgo.trueGroundContact == true)
        {
            trueGroundContact.text = "T_GroundContact: yes";
        }
        else
        {
            trueGroundContact.text = "T_GroundContact: no";
        }
	}
}
