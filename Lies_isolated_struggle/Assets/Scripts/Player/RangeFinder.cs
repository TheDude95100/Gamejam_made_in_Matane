using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Map;
using UnityEngine;

public class RangeFinder
{
    public List<OverlayTile> GetTilesInRange(OverlayTile startingTile, int range)
    {
        var tilesInRange = new List<OverlayTile>();
        int stepCount = 0;
        
        tilesInRange.Add(startingTile);

        var tileForPreviousStep = new List<OverlayTile>();

        while (stepCount < range)
        {
            var surroundingTiles = new List<OverlayTile>();

            foreach (var item in tileForPreviousStep)
            {
                surroundingTiles.AddRange(MapManager.Instance.GetNeightbourOverlayTiles(item));
            }
            
            tilesInRange.AddRange(surroundingTiles);
            tileForPreviousStep = surroundingTiles.Distinct().ToList();
            stepCount++;
            
        }
        
        return tilesInRange.Distinct().ToList();
    }
}
