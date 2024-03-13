using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EntityData_", menuName = "UnitData/Entity")]
public class EntityData : ScriptableObject
{
    [SerializeField]
    private string _name = "...";
    [SerializeField]
    private EntityType _entityType = EntityType.None;
    [SerializeField]
    [Range(0, 100)]
    private float _chanceToDropItem = 0.5f;
    [SerializeField]
    [Tooltip("Range size where the monster will see the player.")]
    private float _rangeOfAwareness = 3f;
    [SerializeField]
    private bool _canEnterCombat = true;

    [SerializeField]
    private int _strengh = 1;
    [SerializeField]
    private int _agility = 1;
    [SerializeField]
    private int _constitution = 1;
    [SerializeField]
    private int _sanity = 1;
    [SerializeField]
    private int _movement = 1;
    [SerializeField]
    private int _maxHPFlatBonus = 0;
    [SerializeField]
    private float _maxHPScaleBonus = 1f;

    [SerializeField]
    private float _fireDamageBonus = 1f;
    [SerializeField]
    private float _meleeDamageBonus = 1f;
    [SerializeField]
    private float _rangedDamageBonus = 1f;

    [SerializeField]
    private float _rangedAccuracyBonus = 1f;
    [SerializeField]
    private float _meleeAccuracyBonus = 1f;

    [SerializeField]
    [Tooltip("Speaks dialogue when entering combat.")]
    [TextArea()]
    private string _battleCry = "...";

    [SerializeField]
    private EntityAbility[] _abilities;
    [SerializeField]
    private EntityTrait[] _traits;

    public string Name => _name;
    public EntityType EntityType => _entityType;
    public float ChanceToDropItem => _chanceToDropItem;
    public float RangeOfAwareness => _rangeOfAwareness;
    public bool CanEnterCombat => _canEnterCombat;

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

    public float RangedAccuracyBonus => _rangedAccuracyBonus;
    public float MeleeAccuracyBonus => _meleeAccuracyBonus;

    public string BattleCry => _battleCry;

    public EntityAbility[] Abilities => _abilities;
    public EntityTrait[] Traits => _traits;
}
