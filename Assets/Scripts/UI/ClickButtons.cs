using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ClickButtons : MonoBehaviour
{
    public Button tryAgainButton;
    public GameObject gameOverPanel;
    void Start()
    {
        Button button = tryAgainButton.GetComponent<Button>();
        button.onClick.AddListener(TaskOnClick);
    }

    public void TaskOnClick()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        gameOverPanel.SetActive(false);
        SceneManager.LoadScene(currentSceneIndex);

    }

    
}
