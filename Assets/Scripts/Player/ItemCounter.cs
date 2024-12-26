using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ItemCounter : MonoBehaviour
{

    public GameObject explosionEffect;
    
    public int NumberOfItems {get; private set; }

    public UnityEvent<ItemCounter> OnItemCollected;
    public void CollectedItem()
    {
        StartCoroutine(TriggerExplosionEffect());
        NumberOfItems++;
        OnItemCollected.Invoke(this);

    }

    private IEnumerator TriggerExplosionEffect()
    {
        explosionEffect.SetActive(true); 
        yield return new WaitForSeconds(0.1f); 
        explosionEffect.SetActive(false); 
    }
}
