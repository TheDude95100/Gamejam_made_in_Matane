using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class MouseController : MonoBehaviour
{
    public GameObject CharacterPrefab;
    private CharacterInfo _character;
    private PathFinder _pathFinder;
    public float speed;
    private List<OverlayTile> path = new List<OverlayTile>();
    
    // Start is called before the first frame update
    void Start()
    {
        _pathFinder = new PathFinder();
    }

    private void LateUpdate()
    {
        var focusedTileHit = GetFocusedOnTile();
        if (focusedTileHit.HasValue)
        {
            GameObject overlayTile = focusedTileHit.Value.collider.gameObject;
            transform.position = overlayTile.transform.position;
            gameObject.GetComponent<SpriteRenderer>().sortingOrder =
                overlayTile.GetComponent<SpriteRenderer>().sortingOrder;
            
            if (Input.GetMouseButtonDown(0))
            {
                overlayTile.GetComponent<OverlayTile>().ShowTile();

                if (_character == null)
                {
                    _character = Instantiate(CharacterPrefab).GetComponent<CharacterInfo>();
                    PositionCharacterOnTile(overlayTile);
                }
                else
                {
                    var path = _pathFinder.FindPath(_character.standingOnTile, overlayTile);
                }
            }
        }

        if (path.Count > 0)
        {
            MoveAlongPath();
        }
    }

    private void MoveAlongPath()
    {
        var step = speed * Time.deltaTime;
        var zIndex = path[0].transform.position.z;
        _character.transform.position =
            Vector2.MoveTowards(_character.transform.position, path[0].transform.position, step);
        _character.transform.position =
            new Vector3(_character.transform.position.x, _character.transform.position.y, zIndex);
        
        if(Vector2.Distance(_character.transform.position, path[0].transform.position) < 0.0001f)
        {
            PositionCharacterOnTile(path[0].gameObject);
            path.RemoveAt(0);
        }
    }

    public RaycastHit2D? GetFocusedOnTile()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePos2d = new Vector2(mousePos.x, mousePos.y);

        RaycastHit2D[] hits = Physics2D.RaycastAll(mousePos2d, Vector2.zero);

        if (hits.Length > 0)
        {
            // return hits.OrderByDescending(i => i.collider.transform.position.z).First();
            return hits.First();
        }
        return null;
    }

    private void PositionCharacterOnTile(GameObject tile)
    {
        _character.transform.position =
            new Vector3(tile.transform.position.x, tile.transform.position.y+0.0001f, tile.transform.position.z);
        _character.GetComponent<SpriteRenderer>().sortingOrder = tile.GetComponent<SpriteRenderer>().sortingOrder;
        _character.standingOnTile = tile;
    }
}
