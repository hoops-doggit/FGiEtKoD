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
        if (colourEffectText == "pink"){
            colourEffectText = other.gameObject.GetComponentInChildren<BakedAnimator>().currentColour;
            Debug.Log("player collided with " + go.name + " and set colour effect to " + colourEffectText);
        }

        else if (colourEffectText != "pink"){
            colourEffectText = "pink";
        }
    }

    private void OnDestroy()
    {
        ColourEffect_CEManager.instance.AddToColourEffectList(id,  colourEffectText);
    }

    private void CheckForColourEffect()
    {
        if (ColourEffect_CEManager.instance.ce_SaveData.savedColourObjects.ContainsKey(id))
        {
            colourEffectText = ColourEffect_CEManager.instance.ce_SaveData.savedColourObjects[id];
            gameObject.GetComponentInChildren<ColourEffect_DS_Static>().ChangeColour(colourEffectText);
        }

        else
        {
            colourEffectText = "pink";
        }
    }

}
