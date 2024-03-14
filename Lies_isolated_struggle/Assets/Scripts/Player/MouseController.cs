using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Map;
using UnityEngine;

public class MouseController : MonoBehaviour
    {
        public GameObject cursor;
        public float speed;
        public GameObject characterPrefab;
        public int Range;
        
        private CharacterInfo _character;
        private PathFinder _pathFinder;
        private RangeFinder _rangeFinder;
        private List<OverlayTile> _path;
        private List<OverlayTile> _inRangeTile = new List<OverlayTile>();

        private void Start()
        {
            _pathFinder = new PathFinder();
            _path = new List<OverlayTile>();
            _rangeFinder = new RangeFinder();
        }

        void LateUpdate()
        {
            RaycastHit2D? hit = GetFocusedOnTile();

            if (hit.HasValue)
            {
                OverlayTile tile = hit.Value.collider.gameObject.GetComponent<OverlayTile>();
                cursor.transform.position = tile.transform.position;
                cursor.gameObject.GetComponent<SpriteRenderer>().sortingOrder = tile.transform.GetComponent<SpriteRenderer>().sortingOrder;
                if (Input.GetMouseButtonDown(0))
                {
                    tile.gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);

                    if (_character == null)
                    {
                        _character = Instantiate(characterPrefab).GetComponent<CharacterInfo>();
                        PositionCharacterOnLine(tile);
                        _character.standingOnTile = tile;
                    } else
                    {
                        _path = _pathFinder.FindPath(_character.standingOnTile, tile);

                        tile.gameObject.GetComponent<OverlayTile>().HideTile();
                    }
                }
            }

            if (_path.Count > 0)
            {
                MoveAlongPath();
            }
        }

        private void GetInRangeTiles()
        {
            _inRangeTile = _rangeFinder.GetTilesInRange(_character.standingOnTile, Range);
            
            
        }

        private void MoveAlongPath()
        {
            var step = speed * Time.deltaTime;

            float zIndex = _path[0].transform.position.z;
            _character.transform.position = Vector2.MoveTowards(_character.transform.position, _path[0].transform.position, step);
            _character.transform.position = new Vector3(_character.transform.position.x, _character.transform.position.y, zIndex);

            if(Vector2.Distance(_character.transform.position, _path[0].transform.position) < 0.00001f)
            {
                PositionCharacterOnLine(_path[0]);
                _path.RemoveAt(0);
            }

        }

        private void PositionCharacterOnLine(OverlayTile tile)
        {
            _character.transform.position = new Vector3(tile.transform.position.x, tile.transform.position.y+0.0001f, tile.transform.position.z);
            _character.GetComponent<SpriteRenderer>().sortingOrder = tile.GetComponent<SpriteRenderer>().sortingOrder;
            _character.standingOnTile = tile;
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
    }
