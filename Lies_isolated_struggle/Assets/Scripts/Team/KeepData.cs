using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepData : MonoBehaviour
{

    [SerializeField] private GameObject[] listCompagnon;
    [SerializeField] private Weapon[] weaponInventory;

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
