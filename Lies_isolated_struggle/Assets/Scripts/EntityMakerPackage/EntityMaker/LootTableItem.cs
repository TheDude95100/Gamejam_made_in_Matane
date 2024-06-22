using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LootTableItem
{
    [SerializeField]
    private GameObject _itemPrefab;

    [SerializeField]
    private int _minQuantityToDrop;
    [SerializeField]
    private int _maxQuantityToDrop;

    [SerializeField]
    private float _chanceToDrop;


    public GameObject ItemPrefab => _itemPrefab;

    public int MinQuantityToDrop => _minQuantityToDrop;
    public int MaxQuantityToDrop => _maxQuantityToDrop;

    public float ChanceToDrop => _chanceToDrop;
}
