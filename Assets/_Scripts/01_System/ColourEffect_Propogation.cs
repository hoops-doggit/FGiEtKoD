using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ColourEffect_Propogation : MonoBehaviour {

    //this will be used between scenes so that 
    public float id;
    public string colourEffectText = "pink";
    //private ColourEffect_SaveData sd;
    private GameObject go;
    private ColourEffect_Data cm;


    //I check my data and create or remove if necessary
	void OnEnable () {
        go = gameObject;
        id = transform.position.x + transform.position.z;

        Invoke("CheckForColourEffect", id/100);
    }

    private void OnTriggerEnter(Collider other)
    {
        colourEffectText = other.gameObject.GetComponentInChildren<BakedAnimator>().currentColour;
        Debug.Log("player collided with " + go.name + " and set colour effect to " + colourEffectText);
    }


    private void OnDestroy()
    {
        ColourEffect_CEManager.instance.AddToColourEffectList(id,  colourEffectText);
        Debug.Log("added " + id + " to the colourEffectManagerDictionary ");
    }

    private void CheckForColourEffect()
    {
        if (ColourEffect_CEManager.instance.ce_SaveData.savedColourObjects.ContainsKey(id))
        {
            colourEffectText = ColourEffect_CEManager.instance.ce_SaveData.savedColourObjects[id];
        }

        else
        {
            colourEffectText = "pink";
        }
    }

}
