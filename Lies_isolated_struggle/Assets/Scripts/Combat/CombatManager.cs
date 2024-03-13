using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    private GameObject[] enemies;
    [SerializeField] private GameObject playerManager;

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

    // Start is called before the first frame update
    void Start()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        PlayerManager.instance.SelectCurrentPlayer(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject[] GetEnemies()
    {
        return enemies;
    }

    public void UpdateEnemyList()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
    }

}
