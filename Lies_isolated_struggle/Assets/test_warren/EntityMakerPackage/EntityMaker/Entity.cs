using Map;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    [SerializeField]
    private EntityData _data;
    public OverlayTile standingOnTile;

    public EntityData Data => _data;
}
