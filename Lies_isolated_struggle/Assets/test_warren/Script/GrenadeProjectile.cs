using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeProjectile : MonoBehaviour
{
    [SerializeField]
    private float explosionDamageRadius = 2f;

    private Vector3 _targetPosition;
    private Action _onGrenadeBehaviorComplete;

    private void Update()
    {
        Vector3 moveDirection = (_targetPosition - transform.position).normalized;
        float moveSpeed = 15f;
        transform.position += moveDirection * moveSpeed * Time.deltaTime;

        float reachedTargetDistance = 0.2f;
        if (Vector3.Distance(transform.position, _targetPosition) < reachedTargetDistance)
        {
            Collider[] colliderArray = Physics.OverlapSphere(_targetPosition, explosionDamageRadius);

            foreach(Collider collider in colliderArray)
            {
                if(collider.TryGetComponent<Unit>(out Unit targetUnit))
                {
                    targetUnit.TakeDamage(20);
                }
            }
            Destroy(gameObject);
            _onGrenadeBehaviorComplete();
        }
    }

    public void Setup(GridPosition targetGrisPosition, Action onGrenadeBehaviorComplete)
    {
        _targetPosition = LevelGrid.Instance.GetWorldPosition(targetGrisPosition);
        _onGrenadeBehaviorComplete = onGrenadeBehaviorComplete;
    }
}
