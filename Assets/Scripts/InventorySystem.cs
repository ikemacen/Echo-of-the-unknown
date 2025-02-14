using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySystem : MonoBehaviour
{
    public List<ItemData> inventory = new List<ItemData>();
    private List<worldItem> itemsToGrab = new List<worldItem>();
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out worldItem item))
        {
            if(!itemsToGrab.Contains(item))
            {
                itemsToGrab.Add(item);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.TryGetComponent(out worldItem item))
        {
            if(itemsToGrab.Contains(item))
            {
                itemsToGrab.Remove(item);
            }
        }
    }

    private void Update()
    {
        if(Input.GetButtonDown("Interact"))
        {
            if(itemsToGrab.Count > 0)
            {
                worldItem itemInWorld = itemsToGrab[0];
                ItemData item = itemInWorld.GetItem();
                inventory.Add(item);
                itemsToGrab.Remove(itemInWorld);
                Destroy(itemInWorld.gameObject);
            }
        }
    }
}
