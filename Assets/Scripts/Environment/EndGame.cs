using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public GameObject victoryPanel;
    public GameObject gameOverEndPanel;
    //ItemCounter itemCounter;
    
    void OnTriggerEnter(Collider other)
    {
        Player player = other.GetComponent<Player>();
        ItemCounter itemCounter = other.GetComponent<ItemCounter>();
        
        if (player != null)
        {
            if (itemCounter != null && itemCounter.NumberOfItems >= 300)
            {
                victoryPanel.SetActive(true);
                Time.timeScale = 0;
            }
        
            else
            {
                gameOverEndPanel.SetActive(true);
                Time.timeScale = 0;
            }
        }
        
        
    }
}
