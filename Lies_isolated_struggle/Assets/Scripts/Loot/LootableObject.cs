using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LootableObject : MonoBehaviour
{
    [SerializeField] private ItemData[] _listLootableItem;
    [SerializeField] private float[] _pourcentDropableChance;
    [SerializeField] private GameObject _lootSlotPanel;
    [SerializeField] private GameObject _lootButtonPrefab;
    [SerializeField] private GameObject _toolTipUI;

    private void Start()
    {
        for(int i=0;i< _listLootableItem.Length;i++)
        {
            float chanceDrop = Random.value*100;
            if(chanceDrop < _pourcentDropableChance[i]) 
            {
                GameObject newLootButton = Instantiate(_lootButtonPrefab,_lootSlotPanel.transform);
                newLootButton.GetComponent<LootButton>().SetItemData(_listLootableItem[i], _toolTipUI);
            }
        }
    }
}
