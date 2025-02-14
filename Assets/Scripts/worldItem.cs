using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class worldItem : MonoBehaviour
{
    [SerializeField] ItemData item;
    
    public string GetItemName()
    {
        return item.name;
    }
    public ItemData GetItem()
    {
        return item;
    }
}
