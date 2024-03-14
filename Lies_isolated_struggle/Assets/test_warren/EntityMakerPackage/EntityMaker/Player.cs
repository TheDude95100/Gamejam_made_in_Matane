using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    const int AFFINITY_MAX = 100,
              AFFINITY_MIN = -100;

    private int _strengh,
                _agility,
                _constitution,
                _sanity,
                _affinity,
                _movement,
                _maxHP,
                _currentHP,
                _maxHPFlatBonus;

    private float _maxHPScaleBonus,
                  _fireDamageBonus,
                  _meleeDamageBonus,
                  _rangedDamageBonus;

    private float _rangedAccuracyBonus,
                  _meleeAccuracyBonus;

    private Weapon _activeWeapon;

    private Weapon[] _weaponList;

    public int Strengh => _strengh;
    public int Agility => _agility;
    public int Constitution => _constitution;
    public int Sanity => _sanity;
    public int Affinity => _affinity;
    public int Movement => _movement;
    public int MaxHP => _maxHP;
    public int CurrentHP => _currentHP;
    public int MaxHPFlatBonus  => _maxHPFlatBonus;
    public float MaxHPScaleBonus => _maxHPScaleBonus;
    public float FireDamageBonus => _fireDamageBonus;
    public float RangedDamageBonus => _rangedDamageBonus;
    public float MeleeDamageBonus => _meleeDamageBonus;
    public float RangedAccuracyBonus => _rangedAccuracyBonus;
    public float MeleeAccuracyBonus => _meleeAccuracyBonus;

    public Weapon ActiveWeapon => _activeWeapon;
    public Weapon[] WeaponList => _weaponList;


    // Start is called before the first frame update
    void Start()
    {
        UpdateStat();
        SetCurrentHP(MaxHP);
        _weaponList = Data.WeaponList;
        SetActiveWeapon(_weaponList[0]);
    }

    private void Update()
    {
        UpdateStat();
    }

    public void SetCurrentHP(int currentHP)
    {
        _currentHP = currentHP;
    }

    public void SetActiveWeapon(Weapon weapon) 
    {
        _activeWeapon = weapon;
    }

    public void DealtDamage(int damage)
    {
        if(CurrentHP - damage <= 0)
        {
            _currentHP = 0;
        }
        else if(CurrentHP - damage >= MaxHP)
        {
            _currentHP = MaxHP;
        }
        else
        {
            _currentHP -= damage;
        }
    }

    public void ChangeAffinity(int amount)
    {
        if (Affinity + amount <= AFFINITY_MIN)
        {
            _affinity = AFFINITY_MIN;
        }
        else if (Affinity + amount >= AFFINITY_MAX)
        {
            _affinity = AFFINITY_MAX;
        }
        else
        {
            _affinity += amount;
        }
    }

    public void UpdateStat()
    {
        _strengh = Data.Strengh;
        _agility = Data.Agility;
        _constitution = Data.Constitution;
        _sanity = Data.Sanity;
        _affinity = Data.Affinity;
        _movement = Data.Movement;
        _maxHPFlatBonus = Data.MaxHPFlatBonus;
        _maxHPScaleBonus = Data.MaxHPScaleBonus;
        _fireDamageBonus = Data.FireDamageBonus;
        _meleeDamageBonus = Data.MeleeDamageBonus;
        _rangedDamageBonus = Data.RangedDamageBonus;
        _rangedAccuracyBonus = Data.RangedAccuracyBonus;
        _meleeAccuracyBonus = Data.MeleeAccuracyBonus;

        if (Data.Traits.Length != 0)
        {
            foreach (EntityTrait trait in Data.Traits)
            {
                _strengh += trait.Strengh;
                _agility += trait.Agility;
                _constitution += trait.Constitution;
                _sanity += trait.Sanity;
                _movement += trait.Movement;
                _maxHPFlatBonus += trait.MaxHPFlatBonus;
                _maxHPScaleBonus *= trait.MaxHPScaleBonus;
                _fireDamageBonus *= trait.FireDamageBonus;
                _meleeDamageBonus *= trait.MeleeDamageBonus;
                _rangedDamageBonus *= trait.RangedDamageBonus;
                _rangedAccuracyBonus *= trait.RangedAccuracyBonus;
                _meleeAccuracyBonus *= trait.MeleeAccuracyBonus;
            }
        }

        _maxHP = Mathf.FloorToInt(Constitution * (3 * MaxHPScaleBonus)) + MaxHPFlatBonus;
    }

    public void UpdateRangeArea(int rangeValue)
    {
        transform.GetChild(0).transform.localScale = new Vector3(2 * rangeValue, 2 * rangeValue);
    }
}