using UnityEngine;
using System;
using System.Collections.Generic;

public class ColourEffect_DictionarySerializer1 : MonoBehaviour, ISerializationCallbackReceiver
{
    //thise two are what need to be serialized
    public List<float> _keys = new List<float>();
    public List<ColourEffect_SaveData> _values = new List<ColourEffect_SaveData>();

    //Unity doesn't know how to serialize a Dictionary
    public Dictionary<float, ColourEffect_SaveData> _myDictionary = new Dictionary<float, ColourEffect_SaveData>()
    {
        //{3f, "I"},
        //{4f, "Love"},
        //{5f, "Unity"},
    };

    public void OnBeforeSerialize()
    {
        _keys.Clear();
        _values.Clear();

        foreach (var kvp in _myDictionary)
        {
            _keys.Add(kvp.Key);
            _values.Add(kvp.Value);
        }
    }

    public void OnAfterDeserialize()
    {
        _myDictionary = new Dictionary<float, ColourEffect_SaveData>();

        for (var i = 0; i != Math.Min(_keys.Count, _values.Count); i++)
            _myDictionary.Add(_keys[i], _values[i]);
    }

    void OnGUI()
    {
        foreach (var kvp in _myDictionary)
            Debug.Log("Key: " + kvp.Key + " value: " + kvp.Value);
    }
}