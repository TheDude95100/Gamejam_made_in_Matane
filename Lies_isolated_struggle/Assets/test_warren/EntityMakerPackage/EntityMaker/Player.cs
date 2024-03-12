using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    private int _strengh,
                _agility,
                _constitution,
                _sanity,
                _maxHP,
                _currentHP,
                _maxHPFlatBonus;

    private float _maxHPScaleBonus,
                  _fireDamageBonus,
                  _meleeDamageBonus,
                  _rangedDamageBonus;

    private float _accuracyBonus;

    public int Strengh => _strengh;
    public int Agility => _agility;
    public int Constitution => _constitution;
    public int Sanity => _sanity;
    public int MaxHP => _maxHP;
    public int CurrentHP => _currentHP;
    public int MaxHPFlatBonus  => _maxHPFlatBonus;
    public float MaxHPScaleBonus => _maxHPScaleBonus;
    public float FireDamageBonus => _fireDamageBonus;
    public float MeleeDamageBonus => _meleeDamageBonus;
    public float RangedDamageBonus => _rangedDamageBonus; 
    public float AccuracyBonus => _accuracyBonus;


    // Start is called before the first frame update
    void Start()
    {
        UpdateStat();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateStat()
    {
        _strengh = Data.Strengh;
        _agility = Data.Agility;
        _constitution = Data.Constitution;
        _sanity = Data.Sanity;
        _maxHPFlatBonus = Data.MaxHPFlatBonus;
        _maxHPScaleBonus = Data.MaxHPScaleBonus;
        _fireDamageBonus = Data.FireDamageBonus;
        _meleeDamageBonus = Data.MeleeDamageBonus;
        _rangedDamageBonus = Data.RangedDamageBonus;

        foreach (EntityTrait trait in Data.Traits)
        {
            _strengh += trait.Strengh;
            _agility += trait.Agility;
            _constitution += trait.Constitution;
            _sanity += trait.Sanity;
            _maxHPFlatBonus += trait.MaxHPFlatBonus;
            _maxHPScaleBonus *= trait.MaxHPScaleBonus;
            _fireDamageBonus *= trait.FireDamageBonus;
            _meleeDamageBonus *= trait.MeleeDamageBonus;
            _rangedDamageBonus *= trait.RangedDamageBonus;
        }

        _maxHP += Mathf.FloorToInt((Constitution * 3) * MaxHPScaleBonus) + MaxHPFlatBonus;
    }

    public void SetCurrentHP(int currentHP)
    {
        _currentHP = currentHP;
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
            _currentHP = damage;
        }
    }
}