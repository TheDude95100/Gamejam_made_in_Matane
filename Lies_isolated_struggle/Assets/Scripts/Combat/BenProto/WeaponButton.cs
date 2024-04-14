using UnityEngine;

namespace Combat.BenProto
{
    public class WeaponButton : MonoBehaviour
    {
        private ItemData _weapon;

        public void SetWeaponName(ItemData weapon)
        {
            _weapon = weapon;
        }

        public ItemData GetWeapon()
        {
            return _weapon;
        }

        public void SetCurrentWeapon()
        {
            PlayerManager.instance.SetRangeArea(_weapon.BaseRange);
            PlayerManager.instance.GetCurrentPlayer().SetActiveWeapon(_weapon);
        }
    }
}
