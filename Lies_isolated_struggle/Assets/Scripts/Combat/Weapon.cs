using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Combat/Weapon")]
public class Weapon : ScriptableObject
{
    [SerializeField]
    private string _name = "...";
    [SerializeField]
    private int _damage = 0;
    [SerializeField]
    private int _range = 0;

    public string Name => _name;
    public int Damage => _damage;
    public int Range => _range;
}