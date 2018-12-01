using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ColourEffect_Propogation : MonoBehaviour {

    //this will be used between scenes so that 
    public float id;
    public string colourEffectText;
    //private ColourEffect_SaveData sd;
    private GameObject go;
    private ColourEffect_Data cm;


    //I check my data and create or remove if necessary
	void OnEnable () {
        go = gameObject;
        id = transform.position.x + transform.position.z;

        if (ColourEffect_CEManager.instance.ce_SaveData.savedColourObjects.ContainsKey(id)){
            cm = ColourEffect_CEManager.instance.ce_SaveData.savedColourObjects[id];
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
        ColourEffect_CEManager.instance.AddToColourEffectList(id, new ColourEffect_Data(id, colourEffectText, go));
    }

}
