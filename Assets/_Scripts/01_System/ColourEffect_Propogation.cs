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
    public string[] allowedColours;


    private void Start()
    {
        go = gameObject;
        id =  transform.position.x + transform.position.z;
        CheckForColourEffect();
    }
    

    private void OnTriggerEnter(Collider other)
    {
        if (colourEffectText == "pink"){
            foreach (string x in allowedColours)
            {
                string colour = other.gameObject.GetComponentInChildren<BakedAnimator>().currentColour;
                if (x == colour)
                {
                    colourEffectText = colour;
                    break;
                }
            }

            //Debug.Log("player collided with " + go.name + " and set colour effect to " + colourEffectText);
        }

        else if (colourEffectText != "pink"){
            colourEffectText = "pink";
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (colourEffectText == "pink")
        {
            foreach (string x in allowedColours)
            {
                //if current colour of character is in the allowed colours list then change
                //this objects current colour text
                string colour = other.gameObject.GetComponentInChildren<BakedAnimator>().currentColour;
                if (x == colour)
                {
                    colourEffectText = colour;
                    break;
                }
            }

            //Debug.Log("player collided with " + go.name + " and set colour effect to " + colourEffectText);
        }

        else if (colourEffectText != "pink")
        {
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

        //Debug.Log("Loaded color for " + id);
    }

}
