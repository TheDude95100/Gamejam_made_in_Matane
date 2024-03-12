using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EntityData_", menuName = "UnitData/Entity")]
public class EntityData: ScriptableObject
{
    [SerializeField]
    private string _name = "...";
    [SerializeField]
    private EntityType _monsterType = EntityType.None;
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
    private int _maxHP;


    [SerializeField]
    [Tooltip("Speaks dialogue when entering combat.")]
    [TextArea()]
    private string _battleCry = "...";

    [SerializeField]
    private EntityAbilty[] _abilities;

    public string Name => _name;
    public EntityType MonsterType => _monsterType;
    public float ChanceToDropItem => _chanceToDropItem;
    public float RangeOfAwareness => _rangeOfAwareness;
    public bool CanEnterCombat => _canEnterCombat;

    public int Strengh => _strengh;
    public int Agility => _agility;
    public int Constitution => _constitution;
    public int Sanity => _sanity;
    public int MaxHP => _maxHP;

    public string BattleCry => _battleCry;

    public EntityAbilty[] Abilities => _abilities;
}
