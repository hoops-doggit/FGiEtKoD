using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class RunLevel : MonoBehaviour {

    public GameObject cutscene;
    public GameObject menuButtons;
    public GameObject skipCutsceneButton;
    public bool doLoadNextFrame;
    private bool startedLoadingGame;

    private void Awake()
    {
        doLoadNextFrame = false;
        menuButtons.SetActive(false);
        cutscene.SetActive(true);
    }

    public void RunLevelOK()
    {
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void SkipCutScene()
    {
        cutscene.SetActive(false);
        menuButtons.SetActive(true);
        skipCutsceneButton.SetActive(false);
        Destroy(cutscene);
        Destroy(skipCutsceneButton);
    }

    public void StartClicked()
    {
        doLoadNextFrame = true;
        if (!startedLoadingGame)
        {
            StartCoroutine(LevelLoaderProcess());
        }
        Debug.Log("doLoadNextFrame");
    }

    public void StartLoading()
    {
        StartCoroutine(LevelLoaderProcess());
    }


    IEnumerator LevelLoaderProcess()
    {
        startedLoadingGame = true;
        AsyncOperation status = SceneManager.LoadSceneAsync("Scene01");
        status.allowSceneActivation = false;

        // Wait until done and collect progress as we go.

        while( !status.isDone ) 
        {
            var loadProgress = status.progress;
            if (loadProgress >= 0.9f)
            {
            Debug.Log("almost done");
            // Almost done.
            break;
            }
            yield return null;
        }

        while (!doLoadNextFrame)
        {
            Debug.Log("still waiting");
            //You can do whatever you want here...  
            yield return new WaitForSeconds(1);
            yield return null;
        }

        status.allowSceneActivation = true;
        yield return status;
    }

}


