using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TraitData_", menuName = "UnitData/Trait")]
public class EntityTrait : ScriptableObject
{
    [SerializeField]
    private string _name = "...";

    [SerializeField]
    [TextArea(0,4)]
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

    [Header("Damage bonuses")]
    [SerializeField]
    private int _fireDamageBonus = 0;
    [SerializeField]
    private int _meleeDamageBonus = 0;
    [SerializeField]
    private int _rangedDamageBonus = 0;


    public string Name => _name;
    public string Description => _name;

    public int Strengh => _strengh;
    public int Agility => _agility;
    public int Constitution => _constitution;
    public int Sanity => _sanity;

    public int FireDamageBonus => _fireDamageBonus;
    public int MeleeDamageBonus => _meleeDamageBonus;
    public int RangedDamageBonus => _rangedDamageBonus;
}
