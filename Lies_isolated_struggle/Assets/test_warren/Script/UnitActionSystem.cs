using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UnitActionSystem : MonoBehaviour
{
    [SerializeField] 
    private Unit selectedUnit;

    [SerializeField]
    private LayerMask unitLayerMask;

    private static UnitActionSystem _instance;

    //public Event EventHandler OnSelectedUnitChanged;

    private void Awake()
    {
        _instance = this;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown((int)MouseButton.Left))
        {
            if(TryHandleUnitSelection())
            {
                return;
            }

            selectedUnit.Move(MouseWorld.GetPosition());
        }
    }

    private bool TryHandleUnitSelection()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, _instance.unitLayerMask))
        {
            if(raycastHit.transform.TryGetComponent<Unit>(out Unit unit))
            {
                return true;
            }
        }
        return false;
    }

    private void SetSelectedUnit(Unit unit)
    {
        selectedUnit = unit;

        //OnSelectedUnitChanged?.Invoke(this, EventArgs.Empty);
    }

    public Unit GetSelectedUnit()
    {
        return selectedUnit;
    }
}
