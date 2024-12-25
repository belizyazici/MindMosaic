using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    public GameObject gameOverPanel; 
    public AudioSource failureSound; 
    public AudioClip failureClip; 
    public AudioSource audioSource; 

    public Animator animator; 
    private bool isDead = false;

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

        if (isDead) return;

        if (player != null)
        {
            isDead = true;
            animator.SetBool("isHit", true);
            
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

