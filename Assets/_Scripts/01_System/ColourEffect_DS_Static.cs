using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DoodleStudio95;


public class ColourEffect_DS_Static : MonoBehaviour {

    private SpriteRenderer ds;

    public Sprite pink;
    public Sprite blue;
    public Sprite green;
    public Sprite orange;
    public Sprite yellow;

    public void ChangeColour(string colour)
    {
        ds = gameObject.GetComponent<SpriteRenderer>();

        if (colour == "blue"){
            ds.sprite = blue;
        }

        else if (colour == "green")
        {
            ds.sprite = green;
        }

        else if (colour == "orange")
        {
            ds.sprite = orange;
        }

        else if(colour == "yellow")
        {
            ds.sprite = (yellow);
        }

        else{
            ds.sprite = (pink);
        }
    }

}
