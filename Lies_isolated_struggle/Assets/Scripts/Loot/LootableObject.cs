using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LootableObject : MonoBehaviour
{
    [SerializeField] private GameObject _lootPanel;
    [SerializeField] private GameObject _lootSlotPanel;
    [SerializeField] private GameObject _lootButtonPrefab;
    [SerializeField] private GameObject _toolTipUI;

    private OutlineSelection _outlineSelection;

    private void Start()
    {
        _outlineSelection = gameObject.GetComponent<OutlineSelection>();
    }

    public void OpenLootPanel(PossibleLoot possibleLoot)
    {
        _lootPanel.SetActive(true);
        InstatiateItemButton(possibleLoot);
    }
    public void CloseLootPanel()
    {
        ClearItemButton();
        _lootPanel.SetActive(false);
        _outlineSelection.DisableOutline();
        _toolTipUI.SetActive(false);
    }

    public void RemoveItem(PossibleLoot possibleLoot,ItemData item)
    {
        possibleLoot.GetLootList().Remove(item);
    }

    private void InstatiateItemButton(PossibleLoot possibleLoot)
    {
        foreach(ItemData item in possibleLoot.GetLootList())
        {
            GameObject newLootButton = Instantiate(_lootButtonPrefab, _lootSlotPanel.transform);
            newLootButton.GetComponent<LootButton>().SetItemData(item, _toolTipUI,gameObject, possibleLoot);
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
