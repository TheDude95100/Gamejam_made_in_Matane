using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShootAction : BaseAction
{
    [SerializeField]
    private int maxShootingDistance = 4;

    private enum State
    {
        Aiming,
        Shooting,
        Cooloff
    }

    private State _currentState;
    private float _stateTimer;
    private Unit _targetUnit;
    private bool _canShootBullet;

    private void Update()
    {
        if (!_isActive)
        {
            return;
        }

        _stateTimer -= Time.deltaTime;

        switch (_currentState)
        {
            case State.Aiming:
            {
                Vector3 rotationDirection = (_targetUnit.GetWorldPosition() - _unit.GetWorldPosition()).normalized;
                float rotateSpeed = 10f;
                transform.forward = Vector3.Lerp(transform.forward, rotationDirection, Time.deltaTime * rotateSpeed);
                break;
            }
            case State.Shooting:
            {
                if(_canShootBullet)
                {
                    Shoot();
                    _canShootBullet = false;
                }
                break;
            }
            case State.Cooloff:
            {
                break;
            }
        }

        if (_stateTimer <= 0f)
        {
            NextState();
        }
    }


    public override string GetActionName()
    {
        return "Shoot";
    }

    public override List<GridPosition> GetValidActionGridPositionList()
    {
        List<GridPosition> validGridPositionList = new List<GridPosition>();

        GridPosition unitGridPosition = _unit.GetGridPosition();

        for (int x = -maxShootingDistance; x <= maxShootingDistance; x++)
        {
            for (int z = -maxShootingDistance; z <= maxShootingDistance; z++)
            {
                GridPosition offsetGridPosition = new GridPosition(x, z);
                GridPosition testGridPosition = unitGridPosition + offsetGridPosition;

                if (!LevelGrid.Instance.IsValidPosition(testGridPosition))
                {
                    continue;
                }

                int testDistance = Mathf.Abs(x) + Mathf.Abs(z);
                if(testDistance > maxShootingDistance)
                {
                    continue;
                }

                if (!LevelGrid.Instance.HasUnitOnGridPosition(testGridPosition))
                {
                    //GridPosition is empty, no unit
                    continue;
                }

                Unit targetUnit = LevelGrid.Instance.GetUnitAtGridPosition(testGridPosition);

                if(targetUnit.IsEnemy() == _unit.IsEnemy())
                {
                    //unit in the same group
                    continue;
                }

                validGridPositionList.Add(testGridPosition);
            }
        }

        return validGridPositionList;
    }
    public override int GetActionPointCost()
    {
        return 2;
    }

    public override void TakeAction(GridPosition gridPosition, Action onActionComplete)
    {
        ActionStart(onActionComplete);
        _canShootBullet = true;

        _targetUnit = LevelGrid.Instance.GetUnitAtGridPosition(gridPosition);

        _currentState = State.Aiming;
        float aimingStateTime = 1f;
        _stateTimer = aimingStateTime;
    }

    private void NextState()
    {
        switch (_currentState)
        {
            case State.Aiming:
            {
                _currentState = State.Shooting;
                float shootingStateTime = 0.1f;
                _stateTimer = shootingStateTime;
                break;
            }
            case State.Shooting:
            {
                _currentState = State.Cooloff;
                float cooloffStateTime = 0.5f;
                _stateTimer = cooloffStateTime;
                break;
            }
            case State.Cooloff:
            {
                ActionComplete();
                break;
            }
        }
    }

    private void Shoot()
    {
        _targetUnit.Damage();
    }
}
