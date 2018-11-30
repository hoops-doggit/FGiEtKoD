using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourEffect_CEManager : MonoBehaviour  {

    //i store data
    public static ColourEffect_CEManager ceMan;
    public static Dictionary<float, ColourEffect_SaveData> savedColourObjects = new Dictionary<float, ColourEffect_SaveData>();
    public static List<ColourEffect_SaveData> ce_sd = new List<ColourEffect_SaveData>();

    private void Awake()
    {

    }

}
