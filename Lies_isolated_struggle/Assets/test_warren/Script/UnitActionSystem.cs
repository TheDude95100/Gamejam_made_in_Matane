using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEngine.UI.CanvasScaler;

public class UnitActionSystem : MonoBehaviour
{
    [SerializeField] 
    private Unit selectedUnit;

    [SerializeField]
    private LayerMask unitLayerMask;

    private bool _isBusy;
    private BaseAction _selectedAction;

    public static UnitActionSystem Instance{ get; private set; }

    public event EventHandler OnSelectedUnitChanged;
    public event EventHandler OnSelectedActionChanged;
    public event EventHandler<bool> OnBusyChanged;
    public event EventHandler OnActionStarted;

    private void Awake()
    {
        if(Instance != null)
        {
            Debug.LogError("There'S more than one UnitActionSystem! " + transform + " - " + Instance);
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    private void Start()
    {
        SetSelectedUnit(selectedUnit);
    }

    private void Update()
    {
        if(_isBusy)
        {
            return;
        }

        if(!TurnSystem.Instance.IsPlayerTurn())
        {
            return;
        }

        if(EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (TryHandleUnitSelection())
        {
            return;
        }

        HandleSelectedAction();
    }

    private bool TryHandleUnitSelection()
    {
        if (Input.GetMouseButtonDown((int)MouseButton.Left))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, Instance.unitLayerMask))
            {
                if (raycastHit.transform.TryGetComponent<Unit>(out Unit unit))
                {
                    if(unit == selectedUnit)
                    {
                        //Unit is already selected
                        return false;
                    }

                    if(unit.IsEnemy())
                    {
                        return false;
                    }

                    SetSelectedUnit(unit);
                    return true;
                }
            }
        }
        return false;
    }

    private void HandleSelectedAction()
    {
        if (Input.GetMouseButtonDown((int)MouseButton.Left))
        {
            GridPosition mouseGridPosition = LevelGrid.Instance.GetGridPosition(MouseWorld.GetPosition());

            if (!_selectedAction.IsValidActionGridPosition(mouseGridPosition))
            {
                return;
            }

            if(!selectedUnit.TrySpendActionPointsToTakeAction(_selectedAction))
            {
                return;
            }
            
            SetBusy();
            _selectedAction.TakeAction(mouseGridPosition, ClearBusy);

            OnActionStarted?.Invoke(this, EventArgs.Empty);
        }
    }

    private void SetBusy()
    {
        _isBusy = true;
        OnBusyChanged?.Invoke(this, _isBusy);
    }

    private void ClearBusy()
    {
        _isBusy = false;
        OnBusyChanged?.Invoke(this, _isBusy);
    }

    private void SetSelectedUnit(Unit unit)
    {
        selectedUnit = unit;
        SetSelectedAction(unit.GetMoveAction());

        OnSelectedUnitChanged?.Invoke(this, EventArgs.Empty);
    }

    public void SetSelectedAction(BaseAction baseAction)
    {
        _selectedAction = baseAction;

        OnSelectedActionChanged?.Invoke(this, EventArgs.Empty);
    }

    public Unit GetSelectedUnit()
    {
        return selectedUnit;
    }

    public BaseAction GetSelectedAction()
    {
        return _selectedAction;
    }
}
