using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    public GameObject gameOverPanel; 
    public AudioSource failureSound; 
    public AudioClip failureClip; 
    public AudioSource audioSource; 
    void Start()
    {
        if (audioSource == null)
        {
            audioSource = FindObjectOfType<AudioSource>();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Player player = other.GetComponent<Player>();

        if (player != null)
        {
            player.runSpeed = 0; 
            gameOverPanel.gameObject.SetActive(true); 

            if (failureSound != null && failureClip != null)
            {
                failureSound.clip = failureClip;
                failureSound.Play();
            }

            StopMusic();
        }
    }

    public void StopMusic()
    {
        if (audioSource != null && audioSource.isPlaying)
        {
            audioSource.Stop(); 
        }
    }
}

