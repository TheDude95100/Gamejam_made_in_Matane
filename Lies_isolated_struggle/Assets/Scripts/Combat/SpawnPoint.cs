using Map;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SpawnPoint
{
    [SerializeField] private int _XPos;
    [SerializeField] private int _YPos;

    public SpawnPoint(int XPos, int YPos)
    {
        _XPos = XPos;
        _YPos = YPos;
    }

    public OverlayTile GetTile()
    {
        return MapManager.Instance.map[new Vector2Int(_XPos, _YPos)];
    }
}
