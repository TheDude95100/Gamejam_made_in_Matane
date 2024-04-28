using System;
using System.Collections.Generic;
using Player;
using UnityEngine;

namespace Map
{
    public class OverlayTile : MonoBehaviour
    {
        public int G;
        public int H;
        public int F => G + H;

        public bool isBlocked = false;

        public OverlayTile Previous;

        public Vector3Int gridLocation;
        public Vector2Int grid2DLocation => new Vector2Int(gridLocation.x, gridLocation.y);
        
        public List<Sprite> arrows;

        private Color actualTileColor = new Color(1, 1, 1, 1);

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                HideTile();
            }
        }

        public void ShowTile()
        { 
            gameObject.GetComponent<SpriteRenderer>().color = actualTileColor;
        }

        public void ChangeColor(int showMode)
        {
           switch (showMode)
           {
                case 0: actualTileColor = new Color(1, 1, 1, 1); break; // Movement color
                case 1: actualTileColor = new Color(1, 0, 0, 1); break; // Attack color
           }
           gameObject.GetComponent<SpriteRenderer>().color = actualTileColor;
        }

        public void HideTile()
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
        }
        
        public void SetSprite(ArrowTranslator.ArrowDirection direction)
        {
            if (direction == ArrowTranslator.ArrowDirection.None)
                GetComponentsInChildren<SpriteRenderer>()[1].color = new Color(1, 1, 1, 0);
            else
            {
                GetComponentsInChildren<SpriteRenderer>()[1].color = new Color(1, 1, 1, 1);
                GetComponentsInChildren<SpriteRenderer>()[1].sprite = arrows[(int)direction];
                GetComponentsInChildren<SpriteRenderer>()[1].sortingOrder = gameObject.GetComponent<SpriteRenderer>().sortingOrder;
            }
        }

    }
}