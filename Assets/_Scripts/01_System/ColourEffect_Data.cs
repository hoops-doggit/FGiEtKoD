using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class ColourEffect_Data //: IComparable<ColourEffect_SaveData>
{

    private float ID { get; set; }
    public string ColourEffect { get; set; }
    public GameObject TargetGameObject { get; set; }

    public ColourEffect_Data(float id, string colourEffect, GameObject targetGameObject){
        this.ID = id;
        this.ColourEffect = colourEffect;
        this.TargetGameObject = targetGameObject;
    }


}
