using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PossibleLoot : MonoBehaviour
{
    [SerializeField] private ItemData[] _listPossibleLootableItem;
    [SerializeField] private float[] _pourcentDropableChance;

    private List<ItemData> _listLootItem = new List<ItemData>();

    private void Start()
    {
        for (int i = 0; i < _listPossibleLootableItem.Length; i++)
        {
            float chanceDrop = Random.value * 100;
            if (chanceDrop < _pourcentDropableChance[i])
            {
                _listLootItem.Add(_listPossibleLootableItem[i]);
            }
        }
    }

    public List<ItemData> GetLootList()
    {
        return _listLootItem;
    }
}
