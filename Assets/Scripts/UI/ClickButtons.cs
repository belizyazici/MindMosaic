using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ClickButtons : MonoBehaviour
{
    public Button tryAgainButton;
    public Button menuButton;
    public Button pauseButton;
    public Button continueButton;
    public Button nextLevelButton;

    public GameObject muteButton;   
    public GameObject unmuteButton; 

    public GameObject gameOverPanel;
    public GameObject pausePanel;
    public GameObject victoryPanel;

    public AudioSource backgroundMusic; 

    void Start()
    {
        tryAgainButton.onClick.AddListener(TryAgain);
        menuButton.onClick.AddListener(GoToMenu);
        pauseButton.onClick.AddListener(PauseGame);
        continueButton.onClick.AddListener(ContinueGame);
        nextLevelButton.onClick.AddListener(GoToNextLevel);

        
        //Those lines will never be activated, they cause error
        //muteButton.SetActive(false); 
        //unmuteButton.SetActive(false); 
    }

    public void TryAgain()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        gameOverPanel.SetActive(false);
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void GoToMenu()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        gameOverPanel.SetActive(false);
        SceneManager.LoadScene(1);
    }

    public void PauseGame()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0;

        muteButton.SetActive(true);
        unmuteButton.SetActive(false); 
    }

    public void ContinueGame()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1;

        //muteButton.SetActive(false);
        //unmuteButton.SetActive(false);
    }

    public void GoToNextLevel()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        victoryPanel.SetActive(false);
        SceneManager.LoadScene(nextSceneIndex);
        Time.timeScale = 1;

        if (nextSceneIndex > PlayerPrefs.GetInt("levelAt"))
        {
            PlayerPrefs.SetInt("levelAt", nextSceneIndex);
        }
    }

    public void MuteMusic()
    {
        if (backgroundMusic != null)
        {
            backgroundMusic.mute = true; 
        }

        muteButton.SetActive(false); 
        unmuteButton.SetActive(true); 
    }

    public void UnmuteMusic()
    {
        if (backgroundMusic != null)
        {
            backgroundMusic.mute = false; 
        }

        muteButton.SetActive(true); 
        unmuteButton.SetActive(false); 
    }
}
