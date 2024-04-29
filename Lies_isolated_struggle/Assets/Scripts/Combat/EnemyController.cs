using Map;
using Player;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject cursor;
    public float speed;
    public GameObject enemyPrefab;
    public List<Enemy> listEnemy;
    public PlayerController playerController;

    private Entity _enemy;
    private bool canSpawn = false;

    void LateUpdate()
    {
        RaycastHit2D? hit = GetFocusedOnTile();

        if (hit.HasValue)
        {
            OverlayTile tile = hit.Value.collider.gameObject.GetComponent<OverlayTile>();
            if (Input.GetMouseButtonDown(0))
            {
                if (_enemy == null && canSpawn)
                {
                    _enemy = Instantiate(enemyPrefab).GetComponent<Enemy>();
                    listEnemy.Add((Enemy)_enemy);
                    PositionCharacterOnTile(tile);
                    canSpawn = false;
                    playerController.GetInRangeTiles();
                }
            }
        }
    }
    private void PositionCharacterOnTile(OverlayTile tile)
    {
        Debug.Log(_enemy.transform.position);
        _enemy.transform.position = new Vector3(tile.transform.position.x, tile.transform.position.y + 0.0001f, tile.transform.position.z);
        _enemy.GetComponent<SpriteRenderer>().sortingOrder = tile.GetComponent<SpriteRenderer>().sortingOrder;
        _enemy.standingOnTile = tile;
    }

    private static RaycastHit2D? GetFocusedOnTile()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

        RaycastHit2D[] hits = Physics2D.RaycastAll(mousePos2D, Vector2.zero);

        if (hits.Length > 0)
        {
            return hits.OrderByDescending(i => i.collider.transform.position.z).First();
        }

        return null;
    }

    public void CanSpawn()
    {
        canSpawn = true;
    }

    public bool GetCanSpawn()
    {
        return canSpawn;
    }
}
