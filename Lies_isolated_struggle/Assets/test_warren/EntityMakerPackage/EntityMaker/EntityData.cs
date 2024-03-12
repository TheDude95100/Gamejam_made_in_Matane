using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EntityData_", menuName = "UnitData/Entity")]
public class EntityData: ScriptableObject
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
    private int _bonusMaxHP;


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
    public int BonusMaxHP => _bonusMaxHP;

    public string BattleCry => _battleCry;

    public EntityAbility[] Abilities => _abilities;
    public EntityTrait[] Traits => _traits;
}
