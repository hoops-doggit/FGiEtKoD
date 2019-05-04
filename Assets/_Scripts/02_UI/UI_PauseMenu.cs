using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_PauseMenu : MonoBehaviour {

    [SerializeField]
    private GameObject restartMenu;

    [SerializeField]
    private GameObject pauseMenu;
    private float backupTimeSetting;

    private void Start()
    {
        restartMenu.SetActive(false);
        if(pauseMenu != null)
        {
            pauseMenu.SetActive(false);
        }

        backupTimeSetting = Time.timeScale;
    }

    public void RestartMenu()
    {
        Time.timeScale = 0;
        restartMenu.SetActive(true);
    }
	
	public void RestartGame()
    {
        _GM.instance.Restart();
    }

    public void ReturnToGame()
    {
        restartMenu.SetActive(false);
        Time.timeScale = backupTimeSetting;
    }
}
