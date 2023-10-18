using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Setting : MonoBehaviour
{
    public GameObject tutorialScreen;
    private bool isOnTutorial;

    public GameObject pauseScreen;
    private bool isOnPause;

    private GameObject settingButton;
    public GameObject endingScreen;

    private void Start()
    {
        settingButton = GameObject.Find("PauseButton");

        AudioManager.instance.ChangeSceneBGM();

        Time.timeScale = 1f;
    }

    public void OnOffTutorial()
    {
        AudioManager.isPressedButton = true;
        if (isOnTutorial)
        {
            tutorialScreen.SetActive(false);
            isOnTutorial = false;
        }
        else
        {
            tutorialScreen.SetActive(true);
            isOnTutorial = true;
        }
    }

    public void PauseResume()
    {
        AudioManager.isPressedButton = true;
        if (isOnPause)
        {
            pauseScreen.SetActive(false);
            settingButton.SetActive(true);
            isOnPause = false;
            Time.timeScale = 1f;
        }
        else
        {
            pauseScreen.SetActive(true);
            settingButton.SetActive(false);
            isOnPause = true;
            Time.timeScale = 0f;
        }
    }

    public void RestartGame()
    {
        AudioManager.isPressedButton = true;
        SceneManager.LoadScene("GameScene");
        if (!endingScreen.activeInHierarchy)
        {
            PauseResume();
        }
        else
        {
            endingScreen.SetActive(false);
        }
        Time.timeScale = 1f;
    }

    public void ReturnToMain()
    {
        AudioManager.isPressedButton = true;
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainTitle");
    }

}
