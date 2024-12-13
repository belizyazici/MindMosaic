using System.Collections;
using UnityEngine;

public class LittleBoyMovement : MonoBehaviour
{
    public float moveSpeed = 2f;   
    public float runDuration = 3f; 
    public GameObject puffEffect;  
    
    private Vector3 direction = Vector3.forward; 

    void Start()
    {
        StartCoroutine(RunAndDisappear());
    }

    IEnumerator RunAndDisappear()
    {
        float elapsedTime = 0f;

        while (elapsedTime < runDuration)
        {
            transform.Translate(direction * moveSpeed * Time.deltaTime);
            elapsedTime += Time.deltaTime;
            yield return null; 
        }

        if (puffEffect != null)
        {
            Instantiate(puffEffect, transform.position, transform.rotation);
        }

        Destroy(gameObject);
    }
}
