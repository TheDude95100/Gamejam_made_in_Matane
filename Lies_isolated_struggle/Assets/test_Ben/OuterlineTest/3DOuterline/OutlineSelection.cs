using UnityEngine;
using UnityEngine.EventSystems;

public class OutlineSelection : MonoBehaviour
{
    private Transform _highlight;
    private Transform _selection;
    private RaycastHit _raycastHit;

    [SerializeField] private Color _outlineColor;
    [SerializeField] private float _outlineThickness;

    private void Awake()
    {
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
                    _selection.GetComponent<LootableObject>().CloseLootPanel();
                    _selection.gameObject.GetComponent<Outline>().enabled = false;
                }
                _selection = _raycastHit.transform;
                _selection.gameObject.GetComponent<Outline>().enabled = true;
                _selection.GetComponent<LootableObject>().OpenLootPanel();
                _highlight = null;
            }
            else
            {
                if (_selection)
                {
                    _selection.GetComponent<LootableObject>().CloseLootPanel();
                    _selection.gameObject.GetComponent<Outline>().enabled = false;
                    _selection = null;
                }
            }
        }
        #endregion
    }

}