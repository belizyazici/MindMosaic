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
    //ItemCounter itemCounter;
    
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
                Time.timeScale = 0;
            }
        }
        
        
    }
}
