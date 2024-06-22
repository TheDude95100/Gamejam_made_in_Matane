using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemData_", menuName = "Datasheet/Item")]
public class ItemData : ScriptableObject
{
    [SerializeField]
    private string _name = "...";
    [SerializeField]
    private ItemType _typeOfItem = ItemType.None;
    [SerializeField]
    private WeaponType _typeOfWeapon = WeaponType.Gun;
    [SerializeField]
    [TextArea(1,4)]
    private string _description = "...";
    [SerializeField]
    [Tooltip("Can the item be equiped by the player either in an equipement slot or in the hotbar.")]
    private bool _isEquipable = false;
    [SerializeField]
    [Tooltip("Can the item be stacked (grouped up) in a single space in the inventory.")]
    private bool _isStackable = false;
    [SerializeField]
    [Tooltip("Maximum amount of the item that can exist in a single stack.")]
    private int _maxQuantity = 0;

    [SerializeField]
    private int _baseDamage = 1;
    [SerializeField]
    private float _baseRange = 1;
    [SerializeField]
    private float _baseAccuracy = 0.5f;

    //guns
    [SerializeField]
    private int _baseMagazineSize = 1;
    [SerializeField]
    private int _basePelletsPerShot = 1;
    [SerializeField]
    private int _baseBulletsPerShot = 1;
    [Tooltip("Number of time the weapon can fire a bullet in a minute")]
    [SerializeField]
    private float _rateOfFire = 1;
    [SerializeField]
    private float _firingCooldown = 1;
    [SerializeField]
    private float _spread = 1;
    [SerializeField]
    private float _reloadSpeed = 1;
    [SerializeField]
    private ShootingType _weaponShootingType = ShootingType.Single;
    
    [SerializeField]
    private int _baseDefense = 0;

    [SerializeField]
    private int _food = 0;
    [SerializeField]
    private int _water = 0;

    [SerializeField]
    private AudioClip _shootingAudio;
    [SerializeField]
    private AudioClip _relaodingAudio;

    public string Name => _name;
    public ItemType TypeOfItem => _typeOfItem;
    public WeaponType TypeOfWeapon => _typeOfWeapon;
    public string Description => _description;
    public bool IsEquipable => _isEquipable;
    public bool IsStackable => _isStackable;
    public int MaxQuantity => _maxQuantity;

    public int BaseDamage => _baseDamage;
    public float BaseRange => _baseRange;
    public float BaseAccuracy => _baseAccuracy;

    public int BaseMagazineSize => _baseMagazineSize;
    public int BasePelletsPerShot => _basePelletsPerShot;
    public int BaseBulletsPerShot => _baseBulletsPerShot;
    public float RateOfFire => _rateOfFire;
    public float FiringCooldown => _firingCooldown;
    public float Spread => _spread;

    public float ReloadSpeed => _reloadSpeed;
    public ShootingType WeaponShootingType => _weaponShootingType;

    public int BaseDefense => _baseDefense;

    public int Food => _food;
    public int Water => _water;

    public AudioClip ShootingAudio => _shootingAudio;
    public AudioClip RelaodingAudio => _relaodingAudio;
}
