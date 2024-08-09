using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LootButton : MonoBehaviour
{
    private GameObject _toolTipUI;
    private ItemData _lootData;
    private GameObject _player;
    private GameObject _lootableObject;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }
    public void OnCursorEnter()
    {
        _toolTipUI.SetActive(true);
        _toolTipUI.GetComponent<TooltipUI>().SetText(_lootData.name, _lootData.Description);
    }

    public void OnCursorExit()
    {
        _toolTipUI.SetActive(false);
    }

    public void SetItemData(ItemData item, GameObject toolTipUI, GameObject lootableObject)
    {
        _lootData = item;
        transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = item.name;
        _toolTipUI = toolTipUI;
        _lootableObject = lootableObject;
    }

    public void Loot()
    {
        _player.GetComponent<PlayerLoot>().AddItem(_lootData);
        _lootableObject.GetComponent<LootableObject>().RemoveItem(_lootData);
    }
}
