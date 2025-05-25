using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinAction : BaseAction
{
    private float rotationAmountDone;

    private void Update()
    {
        if (!_isActive)
        {
            return;
        }

        float spinAmount = 360f * Time.deltaTime;
        transform.eulerAngles += new Vector3(0, spinAmount, 0);
        rotationAmountDone += spinAmount;

        if(rotationAmountDone >= 360)
        {
            _isActive = false;
            _onActionComplete();
        }
    }

    public override string GetActionName()
    {
        return "Spin";
    }

    public override void TakeAction(GridPosition gridPosition, Action onSpinComplete)
    {
        _onActionComplete = onSpinComplete;
        _isActive = true;
        rotationAmountDone = 0;
    }


    public override List<GridPosition> GetValidActionGridPositionList()
    {
        List<GridPosition> validGridPositionList = new List<GridPosition>();
        GridPosition unitGridPosition = _unit.GetGridPosition();

        return new List<GridPosition> {
            unitGridPosition
        };
    }
}
