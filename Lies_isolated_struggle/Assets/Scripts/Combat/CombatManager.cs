using Player;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

namespace Combat.BenProto
{
    public class CombatManager : MonoBehaviour
    {
        public PlayerController playerController;
        public EnemyController enemyController;

        [SerializeField] private GameObject _enemiesListGameobject;
        [SerializeField] private GameObject _characterListGameObject;
        [SerializeField] private GameObject _weaponButtonList;

        private List<Enemy> _enemies = new List<Enemy>();
        private List<Character> _characters = new List<Character>();

        private Character _currentCharacter;
        private int _indexCurrentCharacter = 0;

        private ItemData _currentWeapon;

        [SerializeField] private GameObject _weaponButtonPrefab;

        public ItemData CurrentWeapon => _currentWeapon;

        #region Singleton
        public static CombatManager instance;
        private void Awake()
        {
            if (instance == null)
                instance = this;
            else
            {
                Destroy(gameObject);
            }
        }
        #endregion


        public void UpdateList()
        {
            foreach (Transform enemyGameObject in _enemiesListGameobject.transform)
            {
                _enemies.Add(enemyGameObject.GetComponent<Enemy>());
            }
            foreach (Transform characterGameObject in _characterListGameObject.transform)
            {
                _characters.Add(characterGameObject.GetComponent<Character>());
            }

            _currentCharacter = _characters[_indexCurrentCharacter];
            _currentWeapon = _currentCharacter.ActiveWeapon;
            Debug.Log(_currentCharacter._activeWeapon);
            Debug.Log(_currentCharacter.Data.Name);
            UpdateWeaponButtonList();
        }

        public void NextCharacter()
        {
            _indexCurrentCharacter = (_indexCurrentCharacter + 1) % _characters.Count;
            _currentCharacter = _characters[_indexCurrentCharacter];
        }

        public void UpdateWeaponButtonList()
        {
            foreach (Transform weaponButton in _weaponButtonList.transform)
            {
                Destroy(weaponButton.gameObject);
            }

            foreach(ItemData weapon in _currentCharacter.Data.WeaponList)
            {
                GameObject weaponButton = Instantiate(_weaponButtonPrefab, _weaponButtonList.transform);
                weaponButton.transform.GetComponent<WeaponButton>().SetWeapon(weapon);
                weaponButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = weapon.Name;
            }
        }

        public void SetActiveWeapon(ItemData weapon)
        {
            _currentWeapon = weapon;
            _currentCharacter.SetActiveWeapon(weapon);
        }
    }
}
