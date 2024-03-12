using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class MapManager : MonoBehaviour
{
    private static MapManager _instance;
    public static MapManager Instance { get { return _instance; } }
    [FormerlySerializedAs("OverlayTilePrefab")] public GameObject overlayTilePrefab;
    public GameObject OverlayContainer;
    private void Awake()
    {
        if (_instance != null && _instance != this) {
            Destroy(this.gameObject);
        }
        else {
            _instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Tilemap tileMap = gameObject.GetComponentInChildren<Tilemap>();
        BoundsInt bounds = tileMap.cellBounds;
        
        // Looping through all tiles
        for (int z = bounds.max.z; z > bounds.min.z; z++)
        {
            for (int y = bounds.min.y; y < bounds.max.y; y++)
            {
                for (int x = bounds.min.x; x < bounds.max.x; x++)
                {
                    Vector3Int tileLocation = new Vector3Int(x, y, z);

                    if (tileMap.HasTile(tileLocation))
                    {
                        GameObject overlayTile = Instantiate(overlayTilePrefab, OverlayContainer.transform);
                        Vector3 cellWorldPosition = tileMap.GetCellCenterWorld(tileLocation);

                        overlayTile.transform.position = new Vector3(
                            cellWorldPosition.x,
                            cellWorldPosition.y,
                            cellWorldPosition.z + 1);
                        overlayTile.GetComponent<SpriteRenderer>().sortingOrder = tileMap.GetComponent<TilemapRenderer>().sortingOrder;
                    }
                }
            }
        }
    }
    
}
