using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LootableObject : MonoBehaviour
{
    [SerializeField] private ItemData[] _listPossibleLootableItem;
    [SerializeField] private float[] _pourcentDropableChance;
    [SerializeField] private GameObject _lootPanel;
    [SerializeField] private GameObject _lootSlotPanel;
    [SerializeField] private GameObject _lootButtonPrefab;
    [SerializeField] private GameObject _toolTipUI;

    private List<ItemData> _listLootableItem = new List<ItemData>();

    private void Start()
    {
        for(int i=0;i< _listPossibleLootableItem.Length;i++)
        {
            float chanceDrop = Random.value*100;
            if(chanceDrop < _pourcentDropableChance[i]) 
            {
                _listLootableItem.Add(_listPossibleLootableItem[i]);
            }
        }
    }

    public void OpenLootPanel()
    {
        _lootPanel.SetActive(true);
        InstatiateItemButton();
    }
    public void CloseLootPanel()
    {
        ClearItemButton();
        _lootPanel.SetActive(false);
    }

    public void RemoveItem(ItemData item)
    {
        _listLootableItem.Remove(item);
    }

    private void InstatiateItemButton()
    {
        foreach(ItemData item in _listLootableItem)
        {
            GameObject newLootButton = Instantiate(_lootButtonPrefab, _lootSlotPanel.transform);
            newLootButton.GetComponent<LootButton>().SetItemData(item, _toolTipUI,gameObject);
        }
    }

    private void ClearItemButton()
    {
        for(int i=0;i< _lootSlotPanel.transform.childCount; i++)
        {
            Destroy(_lootSlotPanel.transform.GetChild(i).gameObject);
        }
    }
}
