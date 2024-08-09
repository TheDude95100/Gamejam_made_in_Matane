using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLoot : MonoBehaviour
{
    [SerializeField] private List<ItemData> data;
    
    public void AddItem(ItemData item)
    {
        data.Add(item);
    }
}
