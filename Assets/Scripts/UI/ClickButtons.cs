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
    public Button backButton;
    public Button forthButton;
    public Button nextLevelButton;

    public GameObject gameOverPanel;
    public GameObject pausePanel;
    public GameObject victoryPanel;
    void Start()
    {
        Button t_btn = tryAgainButton.GetComponent<Button>();
        Button m_btn = menuButton.GetComponent<Button>();
        Button p_btn = pauseButton.GetComponent<Button>();
        Button c_btn = continueButton.GetComponent<Button>();
        Button nl_btn = nextLevelButton.GetComponent<Button>();
    

        t_btn.onClick.AddListener(TryAgain);
        m_btn.onClick.AddListener(GoToMenu);
        p_btn.onClick.AddListener(PauseGame);
        c_btn.onClick.AddListener(ContinueGame);
        nl_btn.onClick.AddListener(GoToNextLevel);

    }

    public void TryAgain() // to play again
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        gameOverPanel.SetActive(false);
        SceneManager.LoadScene(currentSceneIndex);

    }

    public void GoToMenu() // to turn back to menu
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        gameOverPanel.SetActive(false);
        SceneManager.LoadScene(1);
    }

    public void PauseGame() // to pause the game
    {
        Player player = GetComponent<Player>();
        pausePanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void ContinueGame() // to continue playing
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void GoToNextLevel() // to go to next level
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


    
}
