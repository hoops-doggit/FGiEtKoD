using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class EndOfLevel : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "player")
        {
            string seconds = _GM.instance.secondsElapsed.text;
            string milliseconds = _GM.instance.millisecondsElapsed.text;
            string time = seconds.ToString() + "." + milliseconds.ToString();
            OnGameOver(time, _GM.instance.numberOfJelliesCollected);
            Debug.Log("PRintinGSTUFF" + time + _GM.instance.numberOfJelliesCollected);
        }
    }

    public void OnGameOver(string time, int jelliesCollected)
    {
        Analytics.CustomEvent("reachedEnd", new Dictionary<string, object>
        {
            { "time", time },
            { "jelliesCollected", jelliesCollected }
        });
    }
}
