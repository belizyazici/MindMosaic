using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ItemCounter : MonoBehaviour
{
    public GameObject victoryPanel;
    public GameObject gameOverEndPanel;
     public int NumberOfItems {get; private set; }

    public UnityEvent<ItemCounter> OnItemCollected;
    public void CollectedItem()
    {
        NumberOfItems++;
        OnItemCollected.Invoke(this);

        if (NumberOfItems >= 300)
        {
            victoryPanel.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
