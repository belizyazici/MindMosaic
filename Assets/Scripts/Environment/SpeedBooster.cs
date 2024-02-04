using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBooster : MonoBehaviour
{
        
    private void OnTriggerEnter(Collider other)
    {
        
        Player player = other.GetComponent<Player>();

        if (player != null)
        {
            player.runSpeed = player.runSpeed * 3;
            Debug.Log("Boosted speed:" + player.runSpeed);
            gameObject.SetActive(false); 

            Invoke("TurnBackToNormal",5);
        }
        
    }

    private void TurnBackToNormal()
    {
        Player player = GameObject.FindObjectOfType<Player>(); // Adjust this if needed
        if (player != null)
        {
            player.runSpeed /= 3;

            Debug.Log("Speed after 5 seconds: " + player.runSpeed);
        }
    }
}
