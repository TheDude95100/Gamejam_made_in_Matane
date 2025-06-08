using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GrenadeProjectile : MonoBehaviour
{
    [SerializeField]
    private float explosionDamageRadius = 2f;
    [SerializeField]
    private Transform grenadeExplosionVFXPrefab;
    [SerializeField]
    private TrailRenderer trailRenderer;
    [SerializeField]
    private AnimationCurve arcYAnimationCurve;

    private Vector3 _targetPosition;
    private Action _onGrenadeBehaviorComplete;
    private float _totalDistance;
    private Vector3 _xzPosition;

    public static event EventHandler OnAnyGrenadeExploded;

    private void Update()
    {
        Vector3 moveDirection = (_targetPosition - _xzPosition).normalized;
        float moveSpeed = 15f;
        _xzPosition += moveDirection * moveSpeed * Time.deltaTime;

        float currentDistance = Vector3.Distance(_xzPosition, _targetPosition);
        float distanceNormalized = 1 - currentDistance / _totalDistance;

        float maxHeight = _totalDistance / 4f;
        float positionY = arcYAnimationCurve.Evaluate(distanceNormalized) * maxHeight;

        transform.position = new Vector3(_xzPosition.x, positionY, _xzPosition.z);

        float reachedTargetDistance = 0.2f;
        if (Vector3.Distance(_xzPosition, _targetPosition) < reachedTargetDistance)
        {
            Collider[] colliderArray = Physics.OverlapSphere(_targetPosition, explosionDamageRadius);

            foreach(Collider collider in colliderArray)
            {
                if(collider.TryGetComponent<Unit>(out Unit targetUnit))
                {
                    targetUnit.TakeDamage(20);
                }
            }
            OnAnyGrenadeExploded?.Invoke(this, EventArgs.Empty);

            trailRenderer.transform.parent = null;

            Instantiate(grenadeExplosionVFXPrefab, _targetPosition + Vector3.up * .5f, Quaternion.identity);

            Destroy(gameObject);

            _onGrenadeBehaviorComplete();
        }
    }

    public void Setup(GridPosition targetGrisPosition, Action onGrenadeBehaviorComplete)
    {
        _targetPosition = LevelGrid.Instance.GetWorldPosition(targetGrisPosition);

        _onGrenadeBehaviorComplete = onGrenadeBehaviorComplete;

        _xzPosition = transform.position;
        _xzPosition.y = 0;
        _totalDistance = Vector3.Distance(_xzPosition, _targetPosition);
    }
}
