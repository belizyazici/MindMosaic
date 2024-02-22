using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    public AudioSource src;
    public AudioClip itemSound;
    private void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
        ItemCounter itemCounter = other.GetComponent<ItemCounter>();

        if (itemCounter != null)
        {
            
            itemCounter.CollectedItem();
            gameObject.SetActive(false); 
            src.clip = itemSound;
            src.Play();
        }
        
    }
    
}
