using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    [SerializeField]  private GameObject[] listPlayer;
    private Player currentPlayer;
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
        currentPlayer = listPlayer[playerIndex].GetComponent<Player>();
        currentPlayer.SetActiveWeapon(currentPlayer.listWeapon[0]);
        SetRangeArea(currentPlayer.GetActiveWeapon().Range);
        foreach(Weapon weapon in currentPlayer.listWeapon)
        {
            GameObject newWeaponButton = Instantiate(prefabWeaponButton, listWeaponButton.transform);
            newWeaponButton.transform.GetChild(0).transform.GetComponent<TextMeshProUGUI>().text = weapon.name;
            WeaponButton weaponButton = newWeaponButton.transform.GetComponent<WeaponButton>();
            weaponButton.SetWeaponName(weapon);
            // newWeaponButton.transform.GetChild(1).transform.GetComponent<Image>().sprite = weapon.imageWeapon;      // A faire quand on aura des images
        }
    }

    public void SetRangeArea(int range)
    {
        currentPlayer.UpdateRangeArea(range);
    }

    public Player GetCurrentPlayer() { return currentPlayer; }
}
