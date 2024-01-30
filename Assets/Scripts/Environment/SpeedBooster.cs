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
            player.runSpeed = player.runSpeed * 5;
            gameObject.SetActive(false); 
        }
        
    }
}
