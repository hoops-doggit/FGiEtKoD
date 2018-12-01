using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ColourEffect_SaveData : MonoBehaviour//, ISerializationCallbackReceiver
{
    public static ColourEffect_SaveData instance;


    public Dictionary<float, string> savedColourObjects = new Dictionary<float, string>();

    //this is going to be where I store all of my colour effected objects
    public List<float> ce_Data1 = new List<float>();
    public List<string> ce_Data2 = new List<string>();
    //public List<GameObject> ce_Data3 = new List<GameObject>();


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        else if (instance != this)
        {
            Destroy(instance);
        }
    }

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
        savedColourObjects = new Dictionary<float, string>();

        for (var i = 0; i != Math.Min(ce_Data1.Count, ce_Data2.Count); i++)
            savedColourObjects.Add(ce_Data1[i], ce_Data2[i]);
    }

}
