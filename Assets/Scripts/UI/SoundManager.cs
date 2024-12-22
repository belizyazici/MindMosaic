using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public AudioClip backgroundMusic; 
    public AudioSource audioSource;  
    public GameObject muteButton; 
    public GameObject unmuteButton;

    void Start()
    {
        muteButton.GetComponent<Button>().onClick.AddListener(StopMusic);
        unmuteButton.GetComponent<Button>().onClick.AddListener(PlayMusic);

        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = backgroundMusic;
        audioSource.loop = true; 
        audioSource.playOnAwake = false; 
        audioSource.volume = 1f; 

        if (backgroundMusic != null)
        {
            Debug.Log("Background music is set, now playing.");
            audioSource.mute = false; 
            audioSource.clip = backgroundMusic;
            audioSource.Play();
            //DontDestroyOnLoad(audioSource.gameObject); 
        }
        else
        {
            Debug.LogError("Background music is not assigned in the inspector.");
        }

        UpdateButtonVisibility();
    }

    public void PlayMusic()
    {
        if (backgroundMusic != null && !audioSource.isPlaying)
        {
            audioSource.Play(); 
            UpdateButtonVisibility(); 
        }
    }

    public void StopMusic()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop(); 
            UpdateButtonVisibility(); 
        }
    }

    private void UpdateButtonVisibility()
    {
        muteButton.SetActive(audioSource.isPlaying); 
        unmuteButton.SetActive(!audioSource.isPlaying); 
    }
}

