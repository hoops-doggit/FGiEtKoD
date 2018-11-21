using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelEndScreen : MonoBehaviour {

    public Text seconds;
    public Text miliseconds;
    public Text jellybeans;
    public _GM gm;

    private void Start()
    {
        seconds.text = gm.secondsElapsed.text;
        miliseconds.text = gm.millisecondsElapsed.text;
        jellybeans.text = gm.jelliesCollected.text;
    }


}
