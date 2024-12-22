using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    public AudioSource src;
    public AudioClip itemSound;
    //public GameObject particleEffect;  
    //public GameObject itemEffect;  


    private void Start()
    {
        //particleEffect.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        Player player = other.GetComponent<Player>();
        if (player != null)
        {
            //particleEffect.SetActive(true);

            //particleEffect.transform.position = player.transform.position;

            //StartCoroutine(DeactivateEffect());

            ItemCounter itemCounter = other.GetComponent<ItemCounter>();
            if (itemCounter != null)
            {
                itemCounter.CollectedItem();
            }

            src.clip = itemSound;
            src.Play();

            //itemEffect.SetActive(false);
            gameObject.SetActive(false);
        }
    }
/*
    private IEnumerator DeactivateEffect()
    {
        yield return new WaitForSeconds(0.2f);

        ParticleSystem ps = particleEffect.GetComponent<ParticleSystem>();
        if (ps != null)
        {
            ps.Stop(); 
        }
    }*/
}
