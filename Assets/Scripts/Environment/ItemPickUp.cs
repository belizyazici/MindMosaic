using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    private void Start()
    {
        //SpawnItems();
    }

    private void OnTriggerEnter(Collider other)
    {
        
        ItemCounter itemCounter = other.GetComponent<ItemCounter>();

        if (itemCounter != null)
        {
            itemCounter.CollectedItem();
            gameObject.SetActive(false); 
        }
        
    }
    /*
    public GameObject itemPrefab;

    void SpawnItems()
    {
        int itemsToSpawn = 10;
        for (int i = 0; i < itemsToSpawn; i++)
        {
            GameObject temp = Instantiate(itemPrefab);
            temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>());
        }
    }
    
    Vector3 GetRandomPointInCollider(Collider collider)
    {
        Vector3 point = new Vector3(
            Random.Range(collider.bounds.min.x, collider.bounds.max.x),
            Random.Range(collider.bounds.min.y, collider.bounds.max.y),
            Random.Range(collider.bounds.min.z, collider.bounds.max.z)
        );

        if (point != collider.ClosestPoint(point))
        {
            point = GetRandomPointInCollider(collider);
        }

        point.y = 1;
        return point;
    }
    */
}
