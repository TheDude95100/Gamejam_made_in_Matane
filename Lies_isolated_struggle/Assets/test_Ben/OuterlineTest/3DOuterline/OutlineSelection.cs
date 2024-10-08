using UnityEngine;
using UnityEngine.EventSystems;

public class OutlineSelection : MonoBehaviour
{
    [SerializeField] private Color _outlineColor;
    [SerializeField] private float _outlineThickness;

    private LootableObject lootableObject;
    private Transform _highlight;
    private Transform _selection;
    private RaycastHit _raycastHit;

    private void Awake()
    {
        lootableObject = gameObject.GetComponent<LootableObject>();
        GameObject[] listSelectable = GameObject.FindGameObjectsWithTag("Selectable");
        foreach (GameObject go in listSelectable) 
        {
            Outline outline = go.AddComponent<Outline>();
            outline.OutlineMode = Outline.Mode.OutlineAll;
            outline.OutlineColor = _outlineColor;
            outline.OutlineWidth = _outlineThickness;
            outline.enabled = false;
        }
    }

    void Update()
    {
        if (_highlight != null)
        {
            _highlight.gameObject.GetComponent<Outline>().enabled = false;
            _highlight = null;
        }
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (!EventSystem.current.IsPointerOverGameObject() && Physics.Raycast(ray, out _raycastHit))  //If hover tranform
        {
            _highlight = _raycastHit.transform;
            if (_highlight.CompareTag("Selectable") && _highlight != _selection)
            {
                  _highlight.gameObject.GetComponent<Outline>().enabled = true;
            }
            else
            {
                _highlight = null;
            }
        }

        #region MouseSelect
        if (Input.GetMouseButtonDown(0))
        {
            if (_highlight)
            {
                if (_selection != null)
                {
                    lootableObject.CloseLootPanel();
                }
                _selection = _raycastHit.transform;
                _selection.gameObject.GetComponent<Outline>().enabled = true;
                lootableObject.OpenLootPanel(_selection.GetComponent<PossibleLoot>());
                _highlight = null;
            }
        }
        #endregion
    }

    public void DisableOutline()
    {
        _selection.gameObject.GetComponent<Outline>().enabled = false;
        _selection = null;
    }

}