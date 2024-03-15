using System.Collections;
using System.Collections.Generic;
using Combat.BenProto;
using UnityEngine;

public class KeepData : MonoBehaviour
{

    [SerializeField] private List<GameObject> _listCompagnon;
    [SerializeField] private Weapon[] _weaponInventory;

    public List<GameObject> ListCompagnon => _listCompagnon;

    #region Singleton
    public static KeepData instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    #endregion

}
