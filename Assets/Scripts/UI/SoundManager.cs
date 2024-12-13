using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip backgroundMusic; // Sahnenin müziği
    public AudioSource audioSource;   // Müzik kaynağı

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();

        // Müzik ayarlarını yap
        audioSource.clip = backgroundMusic;
        audioSource.loop = true; // Müzik döngüde çalacak
        audioSource.playOnAwake = false; // Hemen çalmayacak, biz manuel başlatacağız
        audioSource.volume = 1f; // Müzik sesi (0 ile 1 arasında ayarlanabilir)

        if (backgroundMusic != null)
        {
            Debug.Log("Background music is set, now playing.");
            audioSource.mute = false; 
            audioSource.clip = backgroundMusic;
            audioSource.Play(); // Müzik çalmaya başlasın
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
            audioSource.Play(); // Müzik çal
        }
    }

    public void StopMusic()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop(); // Müzik durdur
        }
    }
}