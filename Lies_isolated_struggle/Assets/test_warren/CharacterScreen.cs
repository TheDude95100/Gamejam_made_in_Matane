using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class CharacterScreen : MonoBehaviour
{
    private List<GameObject> _screenPanels;
    private Player _playerData;
    
    // Start is called before the first frame update
    void Awake()
    {
        _screenPanels = new List<GameObject>();
        for(int childIndex = 0; childIndex < this.gameObject.transform.childCount; childIndex++)
        {
            GameObject temp = this.gameObject.transform.GetChild(childIndex).gameObject;

            temp.SetActive(false);
            _screenPanels.Add(temp);
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            ActivateScreen(FindObjectOfType<Player>());
        }
    }

    public void ActivateScreen(Player playerData)
    {
        _playerData = playerData;

        _screenPanels[0].SetActive(true);
        _screenPanels[2].SetActive(true);

        _screenPanels[2].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = _playerData.Data.Name;
        _screenPanels[2].transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = _playerData.CurrentHP + " / " + _playerData.MaxHP;
        _screenPanels[2].transform.GetChild(4).GetComponent<TextMeshProUGUI>().text = _playerData.Strengh+"";
        _screenPanels[2].transform.GetChild(6).GetComponent<TextMeshProUGUI>().text = _playerData.Agility+"";
        _screenPanels[2].transform.GetChild(8).GetComponent<TextMeshProUGUI>().text = _playerData.Constitution+"";
        _screenPanels[2].transform.GetChild(10).GetComponent<TextMeshProUGUI>().text = _playerData.Sanity+"";
        _screenPanels[2].transform.GetChild(12).GetComponent<TextMeshProUGUI>().text = _playerData.Movement+"";

        _screenPanels[3].transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = ((_playerData.FireDamageBonus-1)*100) + "%";
        _screenPanels[3].transform.GetChild(4).GetComponent<TextMeshProUGUI>().text = ((_playerData.MeleeDamageBonus-1)*100) + "%";
        _screenPanels[3].transform.GetChild(6).GetComponent<TextMeshProUGUI>().text = ((_playerData.RangedDamageBonus-1)*100) + "%";
        _screenPanels[3].transform.GetChild(8).GetComponent<TextMeshProUGUI>().text = ((_playerData.MeleeAccuracyBonus-1)*100) + "%";
        _screenPanels[3].transform.GetChild(10).GetComponent<TextMeshProUGUI>().text = ((_playerData.RangedAccuracyBonus-1)*100) + "%";

        for(int index = 0; index < 3; index++)
        {
            if(index <= _playerData.Data.Traits.Count() - 1)
            {
                if(_playerData.Data.Traits[index])
                {
                    _screenPanels[4].transform.GetChild(index + 1).GetComponent<TextMeshProUGUI>().text = _playerData.Data.Traits[index].Name;
                    _screenPanels[4].transform.GetChild(index + 1).gameObject.SetActive(true);
                    continue;
                }
            }
            _screenPanels[4].transform.GetChild(index + 1).gameObject.SetActive(false);
        }

        _screenPanels[5].transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = _playerData.ActiveWeapon.Name;
        _screenPanels[5].transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = _playerData.ActiveWeapon.Damage + "";
        //_screenPanels[5].transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = ((_playerData.ActiveWeapon.Accuracy - 1) * 100) + "%";
    }

    public void ShowExtendedVersion()
    {
        _screenPanels[0].SetActive(false);
        _screenPanels[1].SetActive(true);
        _screenPanels[3].SetActive(true);
        _screenPanels[4].SetActive(true);
        _screenPanels[5].SetActive(true);
    }

    public void ShowBasicVersion()
    {
        _screenPanels[0].SetActive(true);
        _screenPanels[1].SetActive(false);
        _screenPanels[3].SetActive(false);
        _screenPanels[4].SetActive(false);
        _screenPanels[5].SetActive(false);
    }

    public void DisableScreen()
    {
        for (int index = 0; index < _screenPanels.Count; index++)
        {
            _screenPanels[index].SetActive(false);
        }

        _playerData = null;
    }
}
