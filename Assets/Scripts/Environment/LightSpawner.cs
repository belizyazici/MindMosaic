using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSpawner : MonoBehaviour
{
    public List<Transform> spawnPoints = new List<Transform>();
    [SerializeField] private GameObject light;

    private void Start()
    {
        SpawnLightsAtAllPoints();
    }

    void SpawnLightsAtAllPoints()
    {
        if (spawnPoints.Count == 0)
        {
            Debug.LogWarning("No spawn points available.");
            return;
        }

        foreach (Transform spawnPoint in spawnPoints)
        {
            Instantiate(light, spawnPoint.position, Quaternion.identity);
        }
    }
}