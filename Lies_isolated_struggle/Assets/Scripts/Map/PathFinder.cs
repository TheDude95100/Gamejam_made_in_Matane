using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class PathFinder
{
    public List<GameObject> FindPath(GameObject start, GameObject end)
    {
        List<GameObject> openList = new List<GameObject>();
        List<GameObject> closedList = new List<GameObject>();
        
        openList.Add(start);

        while (openList.Count > 0)
        {
            GameObject currentOverlayTile = openList.OrderBy(x => x.gameObject.GetComponent<OverlayTile>().F).First();

            openList.Remove(currentOverlayTile);
            closedList.Add(currentOverlayTile);

            if (currentOverlayTile == end)
            {
                return GetFinishedList(start, end);
            }

            var neighbourTiles = GetNeighbourTiles(currentOverlayTile);

            foreach (GameObject neighbour in neighbourTiles)
            {
                if (neighbour.gameObject.GetComponent<OverlayTile>().isBlocked || 
                    closedList.Contains(neighbour) || 
                    Mathf.Abs(currentOverlayTile.gameObject.GetComponent<OverlayTile>().GridLocation.z) > 1)
                {
                    continue;
                }

                neighbour.gameObject.GetComponent<OverlayTile>().G = GetManhattenDistance(start, neighbour);
                neighbour.gameObject.GetComponent<OverlayTile>().H = GetManhattenDistance(end, neighbour);
                neighbour.gameObject.GetComponent<OverlayTile>().previous = currentOverlayTile;
                
                if (!openList.Contains(neighbour))
                {
                    openList.Add(neighbour);
                }
            }
        }

        return null;
    }

    private List<GameObject> GetFinishedList(GameObject start, GameObject end)
    {
        List<GameObject> finishedList = new List<GameObject>();

        GameObject currentTile = end;

        while (currentTile != start)
        {
            finishedList.Add(currentTile);
            currentTile = currentTile.gameObject.GetComponent<OverlayTile>().previous;
        }
        finishedList.Reverse();
        return finishedList;

    }

    private int GetManhattenDistance(GameObject start, GameObject neighbour) =>
        (start.gameObject.GetComponent<OverlayTile>().GridLocation.x - neighbour.gameObject.GetComponent<OverlayTile>().GridLocation.x) +
        (start.gameObject.GetComponent<OverlayTile>().GridLocation.y - neighbour.gameObject.GetComponent<OverlayTile>().GridLocation.y);

    private List<GameObject> GetNeighbourTiles(GameObject currentOverlayTile)
    {
        var map = MapManager.Instance.map;
        List<GameObject> neighbours = new List<GameObject>();

        // top
        Vector2Int locationToCheck =
            new Vector2Int(currentOverlayTile.gameObject.GetComponent<OverlayTile>().GridLocation.x,
                currentOverlayTile.gameObject.GetComponent<OverlayTile>().GridLocation.y + 1);
        
        if (map.ContainsKey(locationToCheck))
        {
            neighbours.Add(map[locationToCheck]);
        }
        
        // bottom
        locationToCheck =
            new Vector2Int(currentOverlayTile.gameObject.GetComponent<OverlayTile>().GridLocation.x,
                currentOverlayTile.gameObject.GetComponent<OverlayTile>().GridLocation.y - 1);
        
        if (map.ContainsKey(locationToCheck))
        {
            neighbours.Add(map[locationToCheck]);
        }
        
        // right
        locationToCheck =
            new Vector2Int(currentOverlayTile.gameObject.GetComponent<OverlayTile>().GridLocation.x + 1,
                currentOverlayTile.gameObject.GetComponent<OverlayTile>().GridLocation.y);
        
        if (map.ContainsKey(locationToCheck))
        {
            neighbours.Add(map[locationToCheck]);
        }
        
        // left
        locationToCheck =
            new Vector2Int(currentOverlayTile.gameObject.GetComponent<OverlayTile>().GridLocation.x - 1,
                currentOverlayTile.gameObject.GetComponent<OverlayTile>().GridLocation.y);
        
        if (map.ContainsKey(locationToCheck))
        {
            neighbours.Add(map[locationToCheck]);
        }

        return neighbours;
    }
}
