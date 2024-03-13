using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TraitData_", menuName = "UnitData/Trait")]
public class EntityTrait : ScriptableObject
{
    [SerializeField]
    private string _name = "...";

    [SerializeField]
    [TextArea(1,4)]
    private string _description = "...";

    [Header("Affected stats")]
    [SerializeField]
    private int _strengh = 0;
    [SerializeField]
    private int _agility = 0;
    [SerializeField]
    private int _constitution = 0;
    [SerializeField]
    private int _sanity = 0;
    [SerializeField]
    private int _movement = 0;
    [SerializeField]
    private int _maxHPFlatBonus = 0;
    [SerializeField]
    [Range(0.1f,5)]
    private float _maxHPScaleBonus = 1f;

    [Header("Damage bonuses")]
    [SerializeField]
    [Range(0.1f, 3)]
    private float _fireDamageBonus = 1f;
    [SerializeField]
    [Range(0.1f, 3)]
    private float _meleeDamageBonus = 1f;
    [SerializeField]
    [Range(0.1f, 3)]
    private float _rangedDamageBonus = 1f;

    [Header("Accuracy bonuses")]
    [SerializeField]
    private float _accuracyBonus = 0;


    public string Name => _name;
    public string Description => _name;

    public int Strengh => _strengh;
    public int Agility => _agility;
    public int Constitution => _constitution;
    public int Sanity => _sanity;
    public int Movement => _movement;
    public int MaxHPFlatBonus => _maxHPFlatBonus;
    public float MaxHPScaleBonus => _maxHPScaleBonus;

    public float FireDamageBonus => _fireDamageBonus;
    public float MeleeDamageBonus => _meleeDamageBonus;
    public float RangedDamageBonus => _rangedDamageBonus;

    public float AccuracyBonus => _accuracyBonus;
}
