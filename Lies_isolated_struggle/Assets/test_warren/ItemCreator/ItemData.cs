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
    [Tooltip("Can the item be equiped by the player either in an equipement slot or in the hotbar.")]
    private bool _isEquipable = false;
    [SerializeField]
    [Tooltip("Can the item be stacked (grouped up) in a single space in the inventory.")]
    private bool _isStackable = false;
    [SerializeField]
    [Tooltip("Maximum amount of the item that can exist in a single stack.")]
    private int _maxQuantity = 0;

    [SerializeField]
    private int _baseDamage = 1;
    [SerializeField]
    private int _baseRange = 1;
    [SerializeField]
    private float _baseAccuracy = 0.5f;

    [SerializeField]
    private int _baseDefense = 0;


    [SerializeField]
    private int _food = 0;
    [SerializeField]
    private int _water = 0;

    public string Name => _name;
    public ItemType Type => _type;
    public string Description => _description;
    public bool IsEquipable => _isEquipable;
    public bool IsStackable => _isStackable;
    public int MaxQuantity => _maxQuantity;

    public int BaseDamage => _baseDamage;
    public int BaseRange => _baseRange;
    public float BaseAccuracy => _baseAccuracy;

    public int BaseDefense => _baseDefense;

    public int Food => _food;
    public int Water => _water;
}
