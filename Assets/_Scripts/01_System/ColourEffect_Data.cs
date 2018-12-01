using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class ColourEffect_Data : IComparable<ColourEffect_Data>
{

    public float ID { get; set; }
    public string ColourEffect { get; set; }
    public GameObject TargetGameObject { get; set; }

    public ColourEffect_Data(float id, string colourEffect, GameObject targetGameObject){
        this.ID = id;
        this.ColourEffect = colourEffect;
        this.TargetGameObject = targetGameObject;
    }

    public int CompareTo(ColourEffect_Data other)
    {
        //first > second return -1
        //first < second return 1
        //first == second return 0

        if (other.ID < this.ID)
        {
            return -1;
        }
        else if (other.ID > this.ID)
        {
            return 1;
        }
        return 0;
    }


}
