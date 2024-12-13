using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableSpawner : MonoBehaviour
{
    public List<Transform> spawnPoints = new List<Transform>();
    [SerializeField] private GameObject collectable;

    private void Start()
    {
        SpawnCollectablesAtAllPoints();
    }

    void SpawnCollectablesAtAllPoints()
    {
        if (spawnPoints.Count == 0)
        {
            Debug.LogWarning("No spawn points available.");
            return;
        }

        foreach (Transform spawnPoint in spawnPoints)
        {
            Instantiate(collectable, spawnPoint.position, Quaternion.identity);
        }
    }
}
