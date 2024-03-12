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
                _bonusFireDamage,
                _bonusMeleeDamage,
                _bonusRangedDamage;

    public int Strengh => _strengh;
    public int Agility => _agility;
    public int Constitution => _constitution;
    public int Sanity => _sanity;
    public int MaxHP => _maxHP;
    public int CurrentHP => _currentHP;
    public int BonusFireDamage => _bonusFireDamage;
    public int BonusMeleeDamage => _bonusMeleeDamage;
    public int BonusRangedDamage => _bonusRangedDamage;


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

        foreach (EntityTrait trait in Data.Traits)
        {
            _strengh += trait.Strengh;
            _agility += trait.Agility;
            _constitution += trait.Constitution;
            _sanity += trait.Sanity;
            _bonusFireDamage += trait.FireDamageBonus;
            _bonusMeleeDamage += trait.MeleeDamageBonus;
            _bonusRangedDamage += trait.RangedDamageBonus;
        }

        _maxHP = _constitution * 3;
    }

    public void SetCurrentHP(int currentHP)
    {
        _currentHP = currentHP;
    }

    public void DealtDamage(int damage)
    {
        if(CurrentHP + damage <= 0)
        {
            _currentHP = 0;
        }
        else if(CurrentHP + damage >= MaxHP)
        {
            _currentHP = MaxHP;
        }
        else
        {
            _currentHP = damage;
        }
    }
}