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
            ActionComplete();
        }
    }

    public override string GetActionName()
    {
        return "Spin";
    }

    public override void TakeAction(GridPosition gridPosition, Action onActionComplete)
    {
        rotationAmountDone = 0;

        ActionStart(onActionComplete);
    }


    public override List<GridPosition> GetValidActionGridPositionList()
    {
        GridPosition unitGridPosition = _unit.GetGridPosition();

        return new List<GridPosition> {
            unitGridPosition
        };
    }

    public override int GetActionPointCost()
    {
        return 2;
    }

    public override EnemyAIAction GetEnemyAIAction(GridPosition gridPosition)
    {
        return new EnemyAIAction {
            gridPosition = gridPosition,
            actionValue = 0
        };
    }
}
