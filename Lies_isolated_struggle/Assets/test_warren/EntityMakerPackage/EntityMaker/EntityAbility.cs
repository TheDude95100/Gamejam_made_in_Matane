using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ElementType
{
    None,
    Fire,
    Cold,
    Blundgeoning,
    Piercing,
    Slashing,
    Bullet
}

[System.Serializable]
public class EntityAbility
{
    [SerializeField]
    private string _name = ". . .";

    [SerializeField]
    private int _damage = 1;

    [SerializeField]
    private int _range = 1;

    [SerializeField]
    private ElementType _element = ElementType.None;
}
