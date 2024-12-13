using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{
    public Button[] levelButtons;
    public Button forwardButton;
    public Button backwardsButton;

    public AudioSource src;
    public AudioClip buttonClick;

    void Start()
    {
        int maxAccessibleLevel = PlayerPrefs.GetInt("levelAt", 2);

        for (int i = 0; i < levelButtons.Length; i++)
        {
            levelButtons[i].interactable = (i + 2 <= maxAccessibleLevel);
            int levelIndex = i + 2; 
            // Add listener to level buttons and play sound on click
            levelButtons[i].onClick.AddListener(() => {
                PlayButtonSound();
                GoToThatLevel(levelIndex);
            });
        }

        forwardButton.onClick.AddListener(() => {
            PlayButtonSound();
            GoBackOrForth();
        });
        backwardsButton.onClick.AddListener(() => {
            PlayButtonSound();
            GoBackOrForth();
        });
    }

    private void PlayButtonSound()
    {
        if (src != null && buttonClick != null)
        {
            src.clip = buttonClick;
            src.Play();
        }
    }

    private void GoToThatLevel(int levelIndex)
    {
        int sceneIndex = levelIndex;

        if (sceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(sceneIndex);
        }
    }

    private void GoBackOrForth()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        int previousSceneIndex = currentSceneIndex - 1;
        int nextSceneIndex = currentSceneIndex + 1;

        if (UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.CompareTag("Forth") && nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        if (UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.CompareTag("Back") && previousSceneIndex >= 0)
        {
            SceneManager.LoadScene(previousSceneIndex);
        }
    }
}

