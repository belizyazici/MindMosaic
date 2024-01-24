using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        
        ItemCounter itemCounter = other.GetComponent<ItemCounter>();

        if (itemCounter != null)
        {
            itemCounter.CollectedItem();
            gameObject.SetActive(false); 
        }
        
    }
}
