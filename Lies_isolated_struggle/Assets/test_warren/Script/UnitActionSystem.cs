using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
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

            switch(_selectedAction)
            {
                case MoveAction moveAction:
                    {
                        if (selectedUnit.GetMoveAction().IsValidActionGridPosition(mouseGridPosition))
                        {
                            SetBusy();
                            moveAction.Move(mouseGridPosition, ClearBusy);
                        }

                        break;
                    }
                case SpinAction spinAction:
                    {
                        SetBusy();
                        spinAction.Spin(ClearBusy);

                        break;
                    }
            }
        }
    }

    private void SetBusy()
    {
        _isBusy = true;
    }

    private void ClearBusy()
    {
        _isBusy = false;
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
    }

    public Unit GetSelectedUnit()
    {
        return selectedUnit;
    }
}
