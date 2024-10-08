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
    private PossibleLoot _possibleLoot;

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

    public void SetItemData(ItemData item, GameObject toolTipUI, GameObject lootableObject, PossibleLoot possibleLoot)
    {
        _lootData = item;
        transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = item.name;
        _toolTipUI = toolTipUI;
        _lootableObject = lootableObject;
        _possibleLoot = possibleLoot;
    }

    public void Loot()
    {
        Debug.Log("loot : " + _lootData.name);
        _player.GetComponent<PlayerLoot>().AddItem(_lootData);
        _lootableObject.GetComponent<LootableObject>().RemoveItem(_possibleLoot, _lootData);
        _toolTipUI.SetActive(false);
        Destroy(gameObject);
    }
}
