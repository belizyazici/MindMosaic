using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public GameObject victoryPanel;
    public GameObject gameOverEndPanel;
    public AudioSource src; 
    public AudioClip victorySound;
    public AudioClip failureSound;

    public int goal = 30;

    public Animator animator; 
    private bool isDead = false;
    private bool isVictory = false;

    public Camera playerCamera;  
    public Camera victoryCamera; 
    public float cameraRiseSpeed = 2f; 
    public float maxHeight = 10f; 

    public GameObject dustEffect;

    void Start()
    {
        if (victoryCamera != null)
        {
            victoryCamera.gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Player player = other.GetComponent<Player>();
        ItemCounter itemCounter = other.GetComponent<ItemCounter>();
        
        if (player != null)
        {
            if (itemCounter != null && itemCounter.NumberOfItems >= goal)
            {
                victoryPanel.SetActive(true);
                if (src != null && victorySound != null)
                {
                    src.clip = victorySound;
                    src.Play();   
                }
                isVictory = true;
                animator.SetBool("isVictory", true);
                dustEffect.SetActive(false);

                if (playerCamera != null)
                {
                    playerCamera.gameObject.SetActive(false); 
                }
                if (victoryCamera != null)
                {
                    victoryCamera.gameObject.SetActive(true); 
                    StartCoroutine(MoveCameraUpwards()); 
                }
            }
            else
            {
                gameOverEndPanel.SetActive(true);
                if (src != null && failureSound != null)
                {
                    src.clip = failureSound;
                    src.Play();
                }
                isDead = true;
                animator.SetBool("isHit", true);
            }
        }
    }

    private IEnumerator MoveCameraUpwards()
    {
        Vector3 startPosition = victoryCamera.transform.position;
        while (victoryCamera.transform.position.y < maxHeight)
        {
            victoryCamera.transform.position += new Vector3(0, cameraRiseSpeed * Time.deltaTime, 0);
            yield return null;
        }

        victoryCamera.transform.position = new Vector3(startPosition.x, maxHeight, startPosition.z);
    }
}
