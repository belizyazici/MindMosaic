using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    public AudioSource src;
    public AudioClip itemSound;

    [SerializeField] private bool isDoubleEffect = false; // x2 etkisi için flag

    private void OnTriggerEnter(Collider other)
    {
        Player player = other.GetComponent<Player>();
        if (player != null)
        {
            ItemCounter itemCounter = other.GetComponent<ItemCounter>();
            if (itemCounter != null)
            {
                int multiplier = isDoubleEffect ? 2 : 1; // x2 kontrolü
                itemCounter.CollectedItem(multiplier);
            }

            if (src != null && itemSound != null)
            {
                src.clip = itemSound;
                src.Play();
            }

            gameObject.SetActive(false);
        }
    }
}
