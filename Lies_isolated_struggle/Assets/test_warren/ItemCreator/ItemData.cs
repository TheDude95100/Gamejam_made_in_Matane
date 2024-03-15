using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemData_", menuName = "Datasheet/Item")]
public class ItemData : ScriptableObject
{
    [SerializeField]
    private string _name = "...";
    [SerializeField]
    private ItemType _type = ItemType.None;
    [SerializeField]
    [TextArea(1,4)]
    private string _description = "...";
    [SerializeField]
    private bool _isEquipped = false;
    [SerializeField]
    private int _quantity = 0;

    [SerializeField]
    private bool _isAWeapon = false;
    [SerializeField]
    private int _damage = 0;
    [SerializeField]
    private int _range = 0;
    [SerializeField]
    private float _accuracy = 0.5f;

    [SerializeField]
    private bool _isAnArmor = false;
    [SerializeField]
    private int _defense = 0;

    [SerializeField]
    private bool _isAConsumable = false;

    [SerializeField]
    private bool _isAResosurce = false;
    [SerializeField]
    private int _food = 0;
    [SerializeField]
    private int _water = 0;
}
