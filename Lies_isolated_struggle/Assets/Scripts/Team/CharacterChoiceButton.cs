using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterChoiceButton : MonoBehaviour
{
    [SerializeField] private GameObject _characterPrefab;

    private void Start()
    {
        transform.GetChild(0).gameObject.transform.GetComponent<TextMeshProUGUI>().text = _characterPrefab.transform.GetComponent<Player>().Data.Name;
    }

    public void ChooseCharacter()
    {
        if (KeepData.instance.ListCompagnon.Contains(_characterPrefab))
        {
            KeepData.instance.ListCompagnon.Remove(_characterPrefab);
        }
        else
        {
            KeepData.instance.ListCompagnon.Add(_characterPrefab);
        }
    }

    public void SetCharacter(GameObject gameObject)
    {
        _characterPrefab = gameObject;
    }

    public GameObject GetCharacterPrefab() 
    {  
        return _characterPrefab; 
    }
}
