using Map;
using Player;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject cursor;
    public float speed;
    public GameObject enemyPrefab;
    public PlayerController playerController;
    public List<Vector2Int> listSpawnPoints;
    public List<Enemy> listEnemy;
    public int numberEnemy = 2;
    public GameObject listEnemyParent;

    //private Entity _enemyComponent;

    private bool canSpawn = false;

    private void Start()
    {
        for(int i=0; i< numberEnemy; i++)
        {
            Vector2Int randomSpawnCoord = listSpawnPoints[Random.Range(0, listSpawnPoints.Count - 1)];
            SpawnPoint randomSpawnPoint = new SpawnPoint(randomSpawnCoord.x, randomSpawnCoord.y);
            Enemy _enemyComponent = Instantiate(enemyPrefab, listEnemyParent.transform).GetComponent<Enemy>();
            PositionCharacterOnTile(randomSpawnPoint.GetTile(), _enemyComponent);
            listEnemy.Add(_enemyComponent);
            listSpawnPoints.Remove(randomSpawnCoord);
        }
    }
    private void PositionCharacterOnTile(OverlayTile tile, Entity enemy)
    {
        enemy.transform.position = new Vector3(tile.transform.position.x, tile.transform.position.y + 0.0001f, tile.transform.position.z);
        enemy.GetComponent<SpriteRenderer>().sortingOrder = tile.GetComponent<SpriteRenderer>().sortingOrder;
        enemy.standingOnTile = tile;
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
