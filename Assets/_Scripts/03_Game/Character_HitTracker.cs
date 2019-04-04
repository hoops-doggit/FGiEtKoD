using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_HitTracker : MonoBehaviour {

    public static Character_HitTracker instance;
    public bool trackValuesOnline = false;
    public int timesHit = 0;
    public int jelliesCollected = 0;

    public Vector2[] gateValues;
    

    private void Awake()
    {
        instance = this;
    }

    void Start () {
        timesHit = 0;
        jelliesCollected = 0;
	}
	
	public void AddHit()
    {
        timesHit ++;
    }

    public void AddJelly()
    {
        jelliesCollected++;
    }

    public void ResetValues(int gateNumber)
    {
        //take values and send them to the analytics thing
        gateValues[gateNumber].x= timesHit;
        gateValues[gateNumber].y = jelliesCollected;
        timesHit = 0;
        jelliesCollected = 0;
    }
}
