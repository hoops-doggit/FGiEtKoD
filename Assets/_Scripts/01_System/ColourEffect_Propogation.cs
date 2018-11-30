using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ColourEffect_Propogation : MonoBehaviour {

    //this will be used between scenes so that 
    public float id;
    public string colourEffectText;
    //private ColourEffect_SaveData sd;
    private GameObject go;
    private ColourEffect_SaveData cm;


    //I check my data and create or remove if necessary
	void OnEnable () {
        go = gameObject;
        id = transform.position.x + transform.position.z;

        if (ColourEffect_CEManager.savedColourObjects.ContainsKey(id)){
            cm = ColourEffect_CEManager.savedColourObjects[id];
            colourEffectText = cm.ColourEffect;
        }

        else{
            colourEffectText = "pink";
        }
	}

    private void OnCollisionEnter(Collision collision)
    {
        colourEffectText = collision.gameObject.GetComponent<BakedAnimator>().currentColour;
    }

    private void OnDestroy()
    {

        ColourEffect_CEManager.savedColourObjects.Add(id, new ColourEffect_SaveData(id, colourEffectText, go));
    }

}
