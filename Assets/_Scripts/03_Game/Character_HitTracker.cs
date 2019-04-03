using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_HitTracker : MonoBehaviour {

    public static Character_HitTracker instance;

    public int timesHit = 0;

    public int[] gateValues;

    private void Awake()
    {
        instance = this;
    }

    void Start () {
        timesHit = 0;
	}
	
	public void AddHit()
    {
        timesHit ++;
    }

    public void ResetHit(int gateNumber)
    {
        gateValues[gateNumber] = timesHit;
        timesHit = 0;
    }
}
