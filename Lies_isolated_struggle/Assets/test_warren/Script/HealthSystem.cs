using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField]
    private int health = 100;

    private int _healthMax;

    public event EventHandler OnDeath;
    public event EventHandler OnHealthChanged;

    private void Awake()
    {
        _healthMax = health;
    }

    public float GetHealthNormalized()
    {
        return (float)health / _healthMax;
    }

    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;

        if(health < 0)
        {
            health = 0;
        }

        if(health == 0)
        {
            Die();
        }

        OnHealthChanged?.Invoke(this, EventArgs.Empty);
    }

    private void Die()
    {
        OnDeath?.Invoke(this, EventArgs.Empty);
    }
}
