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
    private bool _isEquipable = false;
    [SerializeField]
    private bool _isStackable = false;
    [SerializeField]
    private int _maxQuantity = 0;

    [SerializeField]
    private int _damage = 0;
    [SerializeField]
    private int _range = 0;
    [SerializeField]
    private float _accuracy = 0.5f;

    [SerializeField]
    private int _defense = 0;


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

    public int Damage => _damage;
    public int Range => _range;
    public float Accuracy => _accuracy;

    public int Defense => _defense;

    public int Food => _food;
    public int Water => _water;
}
