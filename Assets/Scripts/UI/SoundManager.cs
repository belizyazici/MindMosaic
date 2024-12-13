using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip backgroundMusic; 
    public AudioSource audioSource;  

    void Start()
    {
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
            DontDestroyOnLoad(audioSource.gameObject); // AudioSource objesini sahneler arası taşıyoruz
        }
        else
        {
            Debug.LogError("Background music is not assigned in the inspector.");
        }
        
        if (audioSource.isPlaying)
        {
            Debug.Log("Ses çalıyor.");
        }
        else
        {
            Debug.Log("Ses çalmıyor.");
        }
    }

    void Update()
    {
        if (audioSource.isPlaying)
        {
            Debug.Log("Music is playing at volume: " + audioSource.volume);
        }
        else
        {
            Debug.Log("Music is not playing.");
        }
    }
    
    public void PlayMusic()
    {
        if (backgroundMusic != null && !audioSource.isPlaying)
        {
            audioSource.Play(); 
        }
    }

    public void StopMusic()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop(); 
    }
}
}