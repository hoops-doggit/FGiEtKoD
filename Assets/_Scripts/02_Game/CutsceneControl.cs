using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneControl : MonoBehaviour {

    public RunLevel runLevel;

	// Use this for initialization
	void RunTheStartLoadingCommand () {
        runLevel.StartLoading();
	}

    void SkipCutScene()
    {
        runLevel.SkipCutScene();
    }
	

}
