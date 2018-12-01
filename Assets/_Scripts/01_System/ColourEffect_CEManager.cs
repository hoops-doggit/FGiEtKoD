﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourEffect_CEManager : MonoBehaviour  {

    //i store data
    public static ColourEffect_CEManager instance;

    public ColourEffect_SaveData ce_SaveData;

    //public static List<ColourEffect_Data> ce_data = new List<ColourEffect_Data>();

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        Load(); 
    }

    private void Save()
    {
        //take that data then put it in playerPreffs
        PlayerPrefs.SetString("ce_save", Score_Serializer.Serialize<ColourEffect_SaveData>(ce_SaveData));
    }

    public void Load()
    {
        if (PlayerPrefs.HasKey("ce_save"))
        {
            ce_SaveData = Score_Serializer.Deserialize<ColourEffect_SaveData>(PlayerPrefs.GetString("ce_save"));
            Debug.Log("Loading colourEffect_SaveData, it does exist");
            Debug.Log(ce_SaveData);
            PropogateColourEffectSaveDataToGameObjects();
        }

        else
        {
            ce_SaveData = new ColourEffect_SaveData();
            Save();
            Debug.Log("No colourEffect_SaveData found, created a new one");
        }
    }

    public void AddToColourEffectList(float id, ColourEffect_Data thingToStore)
    {
        if (ce_SaveData.savedColourObjects.ContainsKey(id))
        {
            ce_SaveData.savedColourObjects.Remove(id);
            ce_SaveData.savedColourObjects.Add(id, thingToStore);
        }

        else
        {
            ce_SaveData.savedColourObjects.Add(id, thingToStore);
        }

        //calling this here may use a bunch of resources. Will Readdress later

        Save();
    }

    public void PropogateColourEffectSaveDataToGameObjects()
    {
        foreach(KeyValuePair<float, ColourEffect_Data> id in ce_SaveData.savedColourObjects)
        {
            GameObject tempGO = id.Value.TargetGameObject;
            tempGO.GetComponent<ColourEffect_Propogation>().colourEffectText = id.Value.ColourEffect;
        }
    }
}
