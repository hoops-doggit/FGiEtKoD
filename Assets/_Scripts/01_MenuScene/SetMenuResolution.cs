using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetMenuResolution : MonoBehaviour {

	// Use this for initialization
	void Awake () {
        int width = 320; // or something else
        int height = 640; // or something else
        bool isFullScreen = false; // should be windowed to run in arbitrary resolution
        int desiredFPS = 60; // or something else

        Screen.SetResolution(width, height, isFullScreen, desiredFPS);
    }
}
