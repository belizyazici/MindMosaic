using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedBooster : MonoBehaviour
{
    public AudioSource boosterSoundSource; 
    public AudioClip boosterSoundClip; 

    public GameObject boosterIcon; // Canvas üzerindeki booster ikonu
    public float boostDuration = 5f; // Booster süresi

    private void OnTriggerEnter(Collider other)
    {
        Player player = other.GetComponent<Player>();

        if (player != null)
        {
            player.runSpeed = player.runSpeed * 2;
            Debug.Log("Boosted speed: " + player.runSpeed);

            PlayBoosterSound();

            gameObject.SetActive(false);

            ShowBoosterIcon(); // İkonu göster

            Invoke("TurnBackToNormal", boostDuration);
        }
    }

    private void TurnBackToNormal()
    {
        Player player = GameObject.FindObjectOfType<Player>();
        if (player != null)
        {
            player.runSpeed /= 3;
            Debug.Log("Speed after 5 seconds: " + player.runSpeed);
        }

        HideBoosterIcon(); // İkonu gizle
    }

    private void PlayBoosterSound()
    {
        if (boosterSoundSource != null && boosterSoundClip != null)
        {
            boosterSoundSource.PlayOneShot(boosterSoundClip);
        }
    }

    private void ShowBoosterIcon()
    {
        if (boosterIcon != null)
        {
            boosterIcon.SetActive(true); // İkonu aktif et
        }
    }

    private void HideBoosterIcon()
    {
        if (boosterIcon != null)
        {
            boosterIcon.SetActive(false); // İkonu pasif yap
        }
    }
}
