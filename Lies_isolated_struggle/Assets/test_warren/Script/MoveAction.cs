using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAction : MonoBehaviour
{
    [SerializeField] 
    private Animator unitAnimator;
    [SerializeField]
    private int maxMovementDistance = 4;

    private Vector3 _targetPosition;
    private Unit _unit;

    private void Awake()
    {
        _unit = GetComponent<Unit>();
        _targetPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float stoppingDistance = .1f;

        if (Vector3.Distance(_targetPosition, transform.position) > stoppingDistance)
        {
            Vector3 moveDirection = (_targetPosition - transform.position).normalized;
            float moveSpeed = 4f;
            transform.position += moveDirection * moveSpeed * Time.deltaTime;

            float rotateSpeed = 10f;
            transform.forward = Vector3.Lerp(transform.forward, moveDirection, Time.deltaTime * rotateSpeed);

            unitAnimator.SetBool("IsWalking", true);
        }
        else
        {
            unitAnimator.SetBool("IsWalking", false);
        }
    }

    public void Move(GridPosition targetGridPosition)
    {
        _targetPosition = LevelGrid.Instance.GetWorldPosition(targetGridPosition);
    }

    public bool IsValidActionGridPosition(GridPosition gridPosition)
    {
        List<GridPosition> validGridPositionList = GetValidActionGridPositionList();
        return validGridPositionList.Contains(gridPosition);
    }

    public List<GridPosition> GetValidActionGridPositionList()
    {
        List<GridPosition> validGridPositionList = new List<GridPosition>();

        GridPosition unitGridPosition = _unit.GetGridPosition();

        for (int x = -maxMovementDistance; x <= maxMovementDistance; x++)
        {
            for (int z = -maxMovementDistance; z <= maxMovementDistance; z++)
            {
                GridPosition offsetGridPosition = new GridPosition(x, z);
                GridPosition testGridPosition = unitGridPosition + offsetGridPosition;

                if (!LevelGrid.Instance.IsValidPosition(testGridPosition))
                {
                    continue;
                }

                if (testGridPosition == unitGridPosition)
                {
                    //position the unit is already at
                    continue;
                }

                if(LevelGrid.Instance.HasUnitOnGridPosition(testGridPosition))
                {
                    //GridPosition already occupied
                    continue;
                }

                validGridPositionList.Add(testGridPosition);
            }
        }

        return validGridPositionList;
    }
}
