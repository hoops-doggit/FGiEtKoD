using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class ColourEffect_SaveData //: IComparable<ColourEffect_SaveData>
{

    private float ID { get; set; }
    public string ColourEffect { get; set; }
    private GameObject TargetGameObject { get; set; }

    public ColourEffect_SaveData(float id, string colourEffect, GameObject targetGameObject){
        this.ID = id;
        this.ColourEffect = colourEffect;
        this.TargetGameObject = targetGameObject;
    }


}
