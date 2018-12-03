using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DoodleStudio95;


public class ColourEffect_DS_Static : MonoBehaviour {

    private DoodleAnimator ds;

    public DoodleAnimationFile pink;
    public DoodleAnimationFile blue;
    public DoodleAnimationFile green;
    public DoodleAnimationFile orange;
    public DoodleAnimationFile yellow;

    public void ChangeColour(string colour)
    {
        ds = gameObject.GetComponent<DoodleAnimator>();

        if (colour == "blue"){
            ds.ChangeAnimation(blue);
        }

        else if (colour == "green")
        {
            ds.ChangeAnimation(green);
        }

        else if (colour == "orange")
        {
            ds.ChangeAnimation(orange);
        }

        else if(colour == "yellow")
        {
            ds.ChangeAnimation(yellow);
        }

        else{
            ds.ChangeAnimation(pink);
        }
    }

}
