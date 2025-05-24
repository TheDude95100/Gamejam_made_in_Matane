using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    [SerializeField]
    private Transform gridObjectDebugPrefab;

    private GridSystem gridSystem;

    private void Start()
    {
        gridSystem = new GridSystem(10, 10, 1f);

        Debug.Log(new GridPosition(5,7));

        gridSystem.CreateDebugObjects(gridObjectDebugPrefab);
    }

    private void Update()
    {
        Debug.Log(gridSystem.GetGridPosition(MouseWorld.GetPosition()));
    }
}
