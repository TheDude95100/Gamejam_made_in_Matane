using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Unit : MonoBehaviour
{
    private const int ACTION_POINTS_MAX = 2;

    [SerializeField]
    private bool isEnemy;

    private GridPosition _gridPosition;
    private MoveAction _moveAction;
    private SpinAction _spinAction;
    private BaseAction[] _baseActionArray;
    private int _actionPoints;

    public static event EventHandler OnAnyActionPointsChanged;

    private void Awake()
    {
        _actionPoints = ACTION_POINTS_MAX;
        _moveAction = GetComponent<MoveAction>();
        _spinAction = GetComponent<SpinAction>();
        _baseActionArray = GetComponents<BaseAction>();
    }

    private void Start()
    {
        _gridPosition = LevelGrid.Instance.GetGridPosition(transform.position);
        LevelGrid.Instance.AddUnitAtGridPosition(_gridPosition, this);

        TurnSystem.Instance.OnTurnChanged += TurnSystem_OnTurnChanged;
    }

    private void Update()
    {
        GridPosition newGridPosition = LevelGrid.Instance.GetGridPosition(transform.position);

        if(newGridPosition != _gridPosition)
        {
            LevelGrid.Instance.UnitMoveGridPosition(this, _gridPosition, newGridPosition);
            _gridPosition = newGridPosition;
        }
    }

    public MoveAction GetMoveAction()
    {
        return _moveAction;
    }

    public SpinAction GetSpinAction()
    {
        return _spinAction;
    }

    public GridPosition GetGridPosition()
    {
        return _gridPosition;
    }

    public BaseAction[] GetBaseActionArray()
    {
        return _baseActionArray;
    }

    public int GetActionPoints()
    {
        return _actionPoints;
    }

    public bool IsEnemy()
    {
        return isEnemy;
    }

    public bool TrySpendActionPointsToTakeAction(BaseAction baseAction)
    {
        if(CanSpendActionPointsToTakeAction(baseAction))
        {
            SpendActionPoints(baseAction.GetActionPointCost());
            return true;
        }
        return false;
    }

    public bool CanSpendActionPointsToTakeAction(BaseAction baseAction)
    {
        if(_actionPoints >= baseAction.GetActionPointCost())
        {
            return true;
        }

        return false;
    }

    private void SpendActionPoints(int amount)
    {
        _actionPoints -= amount;
        OnAnyActionPointsChanged?.Invoke(this, EventArgs.Empty);
    }

    private void TurnSystem_OnTurnChanged(object sender, EventArgs e)
    {
        if((IsEnemy() && !TurnSystem.Instance.IsPlayerTurn()) ||
           (!IsEnemy() && TurnSystem.Instance.IsPlayerTurn()))
        {
            _actionPoints = ACTION_POINTS_MAX;
            OnAnyActionPointsChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
