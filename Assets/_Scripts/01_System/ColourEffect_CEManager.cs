using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class ColourEffect_CEManager : MonoBehaviour  {

    //i store data
    public static ColourEffect_CEManager instance;

    public ColourEffect_SaveData ce_SaveData = ColourEffect_SaveData.instance;
    private StringWriter writer = new StringWriter();



    //public static List<ColourEffect_Data> ce_data = new List<ColourEffect_Data>();

    private void Awake()
    {
        instance = this;
        //PlayerPrefs.DeleteKey("ce_save1");
        //PlayerPrefs.DeleteKey("ce_save2");

        ce_SaveData = ColourEffect_SaveData.instance;

        Load();
    }

    private void Start()
    {
        Load(); 
    }

    private void Save()
    {
        //take that data then put it in playerPreffs
        //PlayerPrefs.SetString("ce_save", Score_Serializer.Serialize<ColourEffect_SaveData>(ce_SaveData));

        ce_SaveData.OnBeforeSerialize();
        PlayerPrefs.SetString("ce_save1", Score_Serializer.Serialize<List<float>>(ce_SaveData.ce_Data1));
        PlayerPrefs.SetString("ce_save2", Score_Serializer.Serialize<List<string>>(ce_SaveData.ce_Data2));
    }

    public void Load()
    {
        if (PlayerPrefs.HasKey("ce_save1"))
        {            
            ce_SaveData.ce_Data1 = Score_Serializer.Deserialize<List<float>>(PlayerPrefs.GetString("ce_save1"));
            ce_SaveData.ce_Data2 = Score_Serializer.Deserialize<List<string>>(PlayerPrefs.GetString("ce_save2"));
            ce_SaveData.OnAfterDeserialize();


            Debug.Log("Loading colourEffect_SaveData, it does exist");
            //Debug.Log(ce_SaveData);
            //PropogateColourEffectSaveDataToGameObjects();
        }

        else
        {
            ce_SaveData = new ColourEffect_SaveData();
            Save();
            Debug.Log("No colourEffect_SaveData found, created a new one");
        }
    }

    public void AddToColourEffectList(float id, string colourEffect)
    {
        if (ce_SaveData.savedColourObjects.ContainsKey(id))
        {
            ce_SaveData.savedColourObjects.Remove(id);
            ce_SaveData.savedColourObjects.Add(id, colourEffect);
        }

        else
        {
            ce_SaveData.savedColourObjects.Add(id, colourEffect);
        }

        //calling this here may use a bunch of resources. Will Readdress later
        Debug.Log("Saved stuff");
        Save();
    }

    //public void PropogateColourEffectSaveDataToGameObjects()
    //{
    //    foreach (KeyValuePair<float, string> id in ce_SaveData.savedColourObjects)
    //    {
    //        GameObject tempGO = id.Value.TargetGameObject;
    //        tempGO.GetComponent<ColourEffect_Propogation>().colourEffectText = id.Value.ColourEffect;
    //    }
    //}
}
