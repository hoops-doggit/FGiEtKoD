using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class GateScript : MonoBehaviour {

    [SerializeField]
    private int gateNumber;
    private Character_HitTracker hitTracker;

    private void Start()
    {
        hitTracker = Character_HitTracker.instance;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "player")
        {
            int timesHit = hitTracker.timesHit;
            int jelliesCollected = hitTracker.jelliesCollected;
            Debug.Log("went throught zone" + gateNumber + "with " + timesHit + " hits and " + jelliesCollected + " jellies collected");
            hitTracker.ResetValues(gateNumber);
            if (Character_HitTracker.instance.trackValuesOnline)
            {
                Debug.Log("tried to send something");
                SendAnalytics(timesHit, jelliesCollected);
            }
        }
    }

    public void SendAnalytics(int timesHit, int jelliesCollected)
    {
        Analytics.CustomEvent("zone" + gateNumber, new Dictionary<string, object>
        {
            { "times hit", timesHit },
            { "jellies collected", jelliesCollected }
        });
    }


}
