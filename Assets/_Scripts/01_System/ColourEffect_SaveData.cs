using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ColourEffect_SaveData : MonoBehaviour//, ISerializationCallbackReceiver
{

    //public List<ColourEffect_SaveData> colourEffectList;

    public Dictionary<float, ColourEffect_Data> savedColourObjects = new Dictionary<float, ColourEffect_Data>();

    //this is going to be where I store all of my colour effected objects
    public List<float> ce_Data1 = new List<float>();
    public List<ColourEffect_Data> ce_Data2 = new List<ColourEffect_Data>();


    public void OnBeforeSerialize()
    {
        ce_Data1.Clear();
        ce_Data2.Clear();

        foreach (var kvp in savedColourObjects)
        {
            ce_Data1.Add(kvp.Key);
            ce_Data2.Add(kvp.Value);
        }
    }

    public void OnAfterDeserialize()
    {
        savedColourObjects = new Dictionary<float, ColourEffect_Data>();

        for (var i = 0; i != Math.Min(ce_Data1.Count, ce_Data2.Count); i++)
            savedColourObjects.Add(ce_Data1[i], ce_Data2[i]);
    }

}
