using System.Collections.Generic;
using System.Linq;
using Map;
using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        public GameObject cursor;
        public float speed;
        public GameObject characterPrefab;

        private CharacterInfo _character;
        private PathFinder _pathFinder;
        private RangeFinder _rangeFinder;
        private ArrowTranslator _arrowTranslator;
        private List<OverlayTile> _path;
        private List<OverlayTile> _rangeFinderTiles;
        private bool _isMoving;

        private CharacterScreen _characterScreen;

        private void Start()
        {
            _path = new List<OverlayTile>();
            _pathFinder = new PathFinder();
            _rangeFinder = new RangeFinder();
            _arrowTranslator = new ArrowTranslator();
            _isMoving = false;
            _rangeFinderTiles = new List<OverlayTile>();

            _characterScreen = FindObjectOfType<CharacterScreen>();
        }

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.C))
            {
                if(!_characterScreen.IsOpen)
                {
                    _characterScreen.ActivateScreen(FindObjectOfType<Character>());
                    _characterScreen.ToggleIsOpen();
                }
                else
                {
                    _characterScreen.DisableScreen();
                    _characterScreen.ToggleIsOpen();
                }
            }
        }

        void LateUpdate()
        {
            if (_characterScreen.IsOpen)
            {
                return;
            }

            RaycastHit2D? hit = GetFocusedOnTile();

            if (hit.HasValue)
            {
                OverlayTile tile = hit.Value.collider.gameObject.GetComponent<OverlayTile>();
                cursor.transform.position = tile.transform.position;
                cursor.gameObject.GetComponent<SpriteRenderer>().sortingOrder = tile.transform.GetComponent<SpriteRenderer>().sortingOrder;

                if (_rangeFinderTiles.Contains(tile) && !_isMoving)
                {
                    _path = _pathFinder.FindPath(_character.standingOnTile, tile, _rangeFinderTiles);

                    foreach (OverlayTile item in _rangeFinderTiles)
                    {
                        MapManager.Instance.map[item.grid2DLocation].SetSprite(ArrowTranslator.ArrowDirection.None);
                    }

                    for (int i = 0; i < _path.Count; i++)
                    {
                        var previousTile = i > 0 ? _path[i - 1] : _character.standingOnTile;
                        var futureTile = i < _path.Count - 1 ? _path[i + 1] : null;

                        var arrow = _arrowTranslator.TranslateDirection(previousTile, _path[i], futureTile);
                        _path[i].SetSprite(arrow);
                    }
                }

                if (Input.GetMouseButtonDown(0))
                {
                    tile.ShowTile();

                    if (_character == null)
                    {
                        _character = Instantiate(characterPrefab).GetComponent<CharacterInfo>();
                        PositionCharacterOnTile(tile);
                        GetInRangeTiles();
                    }
                    else
                    {
                        _isMoving = true;
                        tile.gameObject.GetComponent<OverlayTile>().HideTile();
                    }
                }
            }

            if (_path.Count > 0 && _isMoving)
            {
                MoveAlongPath();
            }
        }

        private void MoveAlongPath()
        {
            var step = speed * Time.deltaTime;

            float zIndex = _path[0].transform.position.z;
            _character.transform.position = Vector2.MoveTowards(_character.transform.position, _path[0].transform.position, step);
            _character.transform.position = new Vector3(_character.transform.position.x, _character.transform.position.y, zIndex);

            if (Vector2.Distance(_character.transform.position, _path[0].transform.position) < 0.00001f)
            {
                PositionCharacterOnTile(_path[0]);
                _path.RemoveAt(0);
            }

            if (_path.Count == 0)
            {
                GetInRangeTiles();
                _isMoving = false;
            }
        }

        private void PositionCharacterOnTile(OverlayTile tile)
        {
            _character.transform.position = new Vector3(tile.transform.position.x, tile.transform.position.y + 0.0001f, tile.transform.position.z);
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

        private void GetInRangeTiles()
        {
            _rangeFinderTiles = _rangeFinder.GetTilesInRange(new Vector2Int(_character.standingOnTile.gridLocation.x, _character.standingOnTile.gridLocation.y), 3);
        
            foreach (var item in _rangeFinderTiles)
            {
                item.ShowTile();
            }
        }
    }
}
