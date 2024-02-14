using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    private bool buttonPressed = false;
    public AudioClip audioSource;
    public Button playButton;
    void Start()
    {
        Button btn = playButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    public void TaskOnClick()
    {
        PlayButtonClickSound();
        buttonPressed = true;
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex+1;
        SceneManager.LoadScene(nextSceneIndex);
    }

    private void PlayButtonClickSound()
    {
        if (audioSource != null)
        {
            AudioSource.PlayClipAtPoint(audioSource, Camera.main.transform.position);
        }
        else
        {
            Debug.Log("AudioSource component is not assigned");
        }
    }

}
