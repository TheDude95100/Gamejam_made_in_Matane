using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Map
{
    public class PathFinder
    {
        public List<OverlayTile> FindPath(OverlayTile start, OverlayTile end)
        {
            Debug.Log(start.transform.position);
            Debug.Log(end.transform.position);
            List<OverlayTile> openList = new List<OverlayTile>();
            List<OverlayTile> closedList = new List<OverlayTile>();

            openList.Add(start);

            while (openList.Count > 0)
            {
                OverlayTile currentOverlayTile = openList.OrderBy(x => x.F).First();

                openList.Remove(currentOverlayTile);
                closedList.Add(currentOverlayTile);

                if (currentOverlayTile == end)
                {
                    return GetFinishedList(start, end);
                }
                foreach (OverlayTile tile in MapManager.Instance.GetNeightbourOverlayTiles(currentOverlayTile))
                {
                    if (tile.isBlocked || closedList.Contains(tile))
                    {
                        continue;
                    }

                    tile.G = GetManhattenDistance(start, tile);
                    tile.H = GetManhattenDistance(end, tile);

                    tile.Previous = currentOverlayTile;


                    if (!openList.Contains(tile))
                    {
                        openList.Add(tile);
                    }
                }
            }

            return null;
        }

        private List<OverlayTile> GetFinishedList(OverlayTile start, OverlayTile end)
        {
            List<OverlayTile> finishedList = new List<OverlayTile>();
            OverlayTile currentTile = end;

            while (currentTile != start)
            {
                finishedList.Add(currentTile);
                currentTile = currentTile.Previous;
            }

            finishedList.Reverse();

            return finishedList;
        }

        private int GetManhattenDistance(OverlayTile start, OverlayTile tile)
        {
            return Mathf.Abs(start.gridLocation.x - tile.gridLocation.x) +
                   Mathf.Abs(start.gridLocation.y - tile.gridLocation.y);
        }

      
    }
}
