using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ColourEffect_Propogation_Knife : MonoBehaviour {

    //this will be used between scenes so that 
    public float id;
    public string colourEffectText = "pink";
    //private ColourEffect_SaveData sd;
    private GameObject go;
    private GameObject gop;
    private ColourEffect_Data cm;
    public string[] allowedColours;
    private bool loaded;


    private void Start()
    {
        go = gameObject;
        gop = gameObject.transform.parent.gameObject;
        id = transform.position.x + transform.position.z;
        CheckForColourEffect();
        //remind parent 
        gop.GetComponentInParent<Knife_Behaviour>().CheckWhichColourIAm();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (colourEffectText == "pink")
        {
            foreach (string x in allowedColours)
            {
                string colour = other.gameObject.GetComponentInChildren<BakedAnimator>().currentColour;
                if (x == colour)
                {
                    colourEffectText = colour;
                    break;
                }
            }
        }

        else if (colourEffectText != "pink")
        {
            colourEffectText = "pink";
        }
    }



    private void OnDisable()
    {
        if (!loaded)
        {
            ColourEffect_CEManager.instance.AddToColourEffectList(id, colourEffectText);
        }

        else{
            ColourEffect_CEManager.instance.AddToColourEffectList(id, "pink");
        }
    }

    private void CheckForColourEffect()
    {
        if (ColourEffect_CEManager.instance.ce_SaveData.savedColourObjects.ContainsKey(id))
        {
            colourEffectText = ColourEffect_CEManager.instance.ce_SaveData.savedColourObjects[id];
            //this tells the script holding colour variations to change
            gameObject.GetComponentInChildren<ColourEffect_DS_Static>().ChangeColour(colourEffectText);
            gop.GetComponentInParent<Knife_Behaviour>().CheckWhichColourIAm();
            if (colourEffectText != "pink"){
                loaded = true;
            }
        }

        else
        {
            colourEffectText = "pink";
        }

        //Debug.Log("Loaded color for " + id);
    }

}
