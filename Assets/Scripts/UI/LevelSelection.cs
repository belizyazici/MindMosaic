using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{
    public Button[] levelButtons;
    public Button level1;
    public Button level2;
    public Button level3;
    public Button level4;
    public Button level5;
    public Button level6;
    public Button level7;
    public Button level8;
    public Button level9;

    public Button forwardButton;
    public Button backwardsButton;
    void Start()
    {
        Button button1 = level1.GetComponent<Button>();
        Button button2 = level2.GetComponent<Button>();
        Button button3 = level3.GetComponent<Button>();
        Button button4 = level4.GetComponent<Button>();
        Button button5 = level5.GetComponent<Button>();
        Button button6 = level6.GetComponent<Button>();
        Button button7 = level7.GetComponent<Button>();
        Button button8 = level8.GetComponent<Button>();
        Button button9 = level9.GetComponent<Button>();

        Button f_btn = forwardButton.GetComponent<Button>();
        Button b_btn = backwardsButton.GetComponent<Button>();
        
        int levelAt = PlayerPrefs.GetInt("levelAt", 2);

        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i + 2 > levelAt)
            {
                levelButtons[i].interactable = false;
                button1.onClick.AddListener(GoToThatLevel);
                button2.onClick.AddListener(GoToThatLevel);
                button3.onClick.AddListener(GoToThatLevel);
                button4.onClick.AddListener(GoToThatLevel);
                button5.onClick.AddListener(GoToThatLevel);
                button6.onClick.AddListener(GoToThatLevel);
                button7.onClick.AddListener(GoToThatLevel);
                button8.onClick.AddListener(GoToThatLevel);
                button9.onClick.AddListener(GoToThatLevel);

                f_btn.onClick.AddListener(GoBackOrForth);
                b_btn.onClick.AddListener(GoBackOrForth);
            }
        }
        

        
    }

    public void GoToThatLevel()
    {
        if (UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.CompareTag("Level1"))
        {
            SceneManager.LoadScene(2);
        }
        if (UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.CompareTag("Level2"))
        {
            SceneManager.LoadScene(3);
        }
        if (UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.CompareTag("Level3"))
        {
            SceneManager.LoadScene(4);
        }
        if (UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.CompareTag("Level4"))
        {
            SceneManager.LoadScene(5);
        }
        if (UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.CompareTag("Level5"))
        {
            SceneManager.LoadScene(6);
        }
        if (UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.CompareTag("Level6"))
        {
            SceneManager.LoadScene(7);
        }
        if (UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.CompareTag("Level7"))
        {
            SceneManager.LoadScene(8);
        }
        if (UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.CompareTag("Level8"))
        {
            SceneManager.LoadScene(9);
        }
        if (UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.CompareTag("Level9"))
        {
            SceneManager.LoadScene(10);
        }
        
    }

    public void GoBackOrForth(){
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        int previousSceneIndex = currentSceneIndex - 1;
        int nextSceneIndex = currentSceneIndex +1;

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
