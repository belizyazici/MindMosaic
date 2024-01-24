using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountUI : MonoBehaviour
{
    private TextMeshProUGUI itemText;
    void Start()
    {
        itemText = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateItemText(ItemCounter itemCounter)
    {
        itemText.text = itemCounter.NumberOfItems.ToString();
    }
    
}
