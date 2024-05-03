using UnityEngine;

namespace Combat.BenProto
{
    public class WeaponButton : MonoBehaviour
    {
        private ItemData _weapon;

        public void SetWeapon(ItemData weapon)
        {
            _weapon = weapon;
        }

        public ItemData GetWeapon()
        {
            return _weapon;
        }

        public void SetCurrentWeapon()
        {
            Debug.Log(_weapon.Name);
            PlayerManager.instance.SetRangeArea(_weapon.BaseRange);
            PlayerManager.instance.GetCurrentPlayer().SetActiveWeapon(_weapon);


        }
    }
}
