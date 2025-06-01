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

    public event EventHandler<OnShootEventArgs> OnShoot;

    public class OnShootEventArgs : EventArgs
    {
        public Unit targetUnit;
        public Unit shootingUnit;
    }

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
        GridPosition unitGridPosition = _unit.GetGridPosition();
        return GetValidActionGridPositionList(unitGridPosition);
    }

    public List<GridPosition> GetValidActionGridPositionList(GridPosition unitGridPosition)
    {
        List<GridPosition> validGridPositionList = new List<GridPosition>();

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

    public Unit GetTargetUnit()
    {
        return _targetUnit;
    }

    public int GetMaxShootingDistance()
    {
        return maxShootingDistance;
    }

    public override EnemyAIAction GetEnemyAIAction(GridPosition gridPosition)
    {
        Unit targetUnit = LevelGrid.Instance.GetUnitAtGridPosition(gridPosition);
        
        return new EnemyAIAction
        {
            gridPosition = gridPosition,
            actionValue = 100 + Mathf.RoundToInt((1 - targetUnit.GetHealthNormalized()) * 100f)
        };
    }

    public int GetTargetCountAtPosition(GridPosition gridPosition)
    {
        return GetValidActionGridPositionList(gridPosition).Count;
    }

    public override void TakeAction(GridPosition gridPosition, Action onActionComplete)
    {
        _targetUnit = LevelGrid.Instance.GetUnitAtGridPosition(gridPosition);

        _currentState = State.Aiming;
        float aimingStateTime = 1f;
        _stateTimer = aimingStateTime;

        _canShootBullet = true;

        ActionStart(onActionComplete);
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
        OnShoot?.Invoke(this, new OnShootEventArgs {
            targetUnit = _targetUnit,
            shootingUnit = _unit
        });
        _targetUnit.TakeDamage(40);
    }
}
