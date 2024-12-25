using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    public AudioSource src;
    public AudioClip itemSound;

    private void OnTriggerEnter(Collider other)
    {
        Player player = other.GetComponent<Player>();
        if (player != null)
        {
            ItemCounter itemCounter = other.GetComponent<ItemCounter>();
            if (itemCounter != null)
            {
                itemCounter.CollectedItem();
            }

            src.clip = itemSound;
            src.Play();

            gameObject.SetActive(false);
        }
    }

}
