using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class _DegugText : MonoBehaviour {

    public CharacterMovement gbgo;

    public Text groundContact;
    public Text trueGroundContact;
    public Text fast;


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

        if (gbgo.fast)
        {
            fast.text = "fast = true";
        }
        else
        {
            fast.text = "fast = false";
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
