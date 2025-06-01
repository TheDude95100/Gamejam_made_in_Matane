using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinding : MonoBehaviour
{
    [SerializeField]
    private Transform gridObjectDebugPrefab;

    private int _width;
    private int _height;
    private float cellSize;
    private GridSystem<PathNode> _gridSystem;

    private void Awake()
    {
        _gridSystem = new GridSystem<PathNode>(10, 10, 1f, (GridSystem<PathNode> g, GridPosition gridPosition) => new PathNode(gridPosition));
        _gridSystem.CreateDebugObjects(gridObjectDebugPrefab);
    }
}
