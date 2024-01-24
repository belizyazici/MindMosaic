using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ItemCounter : MonoBehaviour
{
     public int NumberOfItems {get; private set; }

    public UnityEvent<ItemCounter> OnItemCollected;
    public void CollectedItem()
    {
        NumberOfItems++;
        OnItemCollected.Invoke(this);
    }
}
