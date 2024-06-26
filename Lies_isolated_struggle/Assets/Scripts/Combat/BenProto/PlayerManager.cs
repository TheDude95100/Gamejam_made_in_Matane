using TMPro;
using UnityEngine;

namespace Combat.BenProto
{
    public class PlayerManager : MonoBehaviour
    {
        [SerializeField]  private GameObject[] listPlayer;
        private Character currentPlayer;
        [SerializeField] private GameObject listWeaponButton;
        [SerializeField] private GameObject prefabWeaponButton;

        #region Singleton
        public static PlayerManager instance;
        private void Awake()
        {
            if (instance == null)
                instance = this;
            else
            {
                Destroy(gameObject);
            }

            listPlayer = GameObject.FindGameObjectsWithTag("Player");
        }
        #endregion

        public void SelectCurrentPlayer(int playerIndex)
        {
            currentPlayer = listPlayer[playerIndex].GetComponent<Character>();
            currentPlayer.SetActiveWeapon(currentPlayer.WeaponList[0]);
            SetRangeArea(Mathf.FloorToInt(currentPlayer.ActiveWeapon.BaseRange));
            foreach(ItemData weapon in currentPlayer.WeaponList)
            {
                GameObject newWeaponButton = Instantiate(prefabWeaponButton, listWeaponButton.transform);
                newWeaponButton.transform.GetChild(0).transform.GetComponent<TextMeshProUGUI>().text = weapon.name;
                WeaponButton weaponButton = newWeaponButton.transform.GetComponent<WeaponButton>();
                weaponButton.SetWeapon(weapon);
                // newWeaponButton.transform.GetChild(1).transform.GetComponent<Image>().sprite = weapon.imageWeapon;      // A faire quand on aura des images
            }
        }

        public void SetRangeArea(int range)
        {
            currentPlayer.UpdateRangeArea(range);
        }

        public Character GetCurrentPlayer() { return currentPlayer; }
    }
}
