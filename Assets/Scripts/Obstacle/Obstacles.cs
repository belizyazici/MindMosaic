using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    public GameObject gameOverPanel;
    void OnTriggerEnter(Collider other){
        Player player = other.GetComponent<Player>();

        if(player != null){
            player.runSpeed = 0;
            gameOverPanel.gameObject.SetActive(true);
        }
    }
}
