using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public GameObject victoryPanel;
    public GameObject gameOverEndPanel;
    public AudioSource src; 
    public AudioClip victorySound;
    public AudioClip failureSound;

    public Animator animator; 
    private bool isDead = false;

    void OnTriggerEnter(Collider other)
    {
        Player player = other.GetComponent<Player>();
        ItemCounter itemCounter = other.GetComponent<ItemCounter>();
        
        if (player != null)
        {
            if (itemCounter != null && itemCounter.NumberOfItems >= 90)
            {
                victoryPanel.SetActive(true);
                victoryPanel.SetActive(true);
                if (src != null && victorySound != null)
                {
                    src.clip = victorySound;
                    src.Play();   
                }   
                // SEVİNÇ ANİM GELMELİ
                Time.timeScale = 0;
            }
        
            else
            {
                gameOverEndPanel.SetActive(true);
                if (src != null && failureSound != null)
                {
                    src.clip = failureSound;
                    src.Play();
                } 
                // DEATH ANIM GELMELİ
                isDead = true;
                animator.SetBool("isHit", true);
                //Time.timeScale = 0;
            }
        }
        
        
    }
}
