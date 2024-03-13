using UnityEngine;

public class WeaponButton : MonoBehaviour
{
    private Weapon _weapon;

    public void SetWeaponName(Weapon weapon)
    {
        _weapon = weapon;
    }

    public Weapon GetWeapon()
    {
        return _weapon;
    }

    public void SetCurrentWeapon()
    {
        PlayerManager.instance.SetRangeArea(_weapon.Range);
        PlayerManager.instance.GetCurrentPlayer().SetActiveWeapon(_weapon);
    }
}
