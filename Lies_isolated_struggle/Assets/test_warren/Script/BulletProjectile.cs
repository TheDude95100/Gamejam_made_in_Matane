using UnityEngine;

public class BulletProjectile : MonoBehaviour
{
    [SerializeField]
    private TrailRenderer trailRenderer;
    [SerializeField]
    private Transform bulletHitVFXPrefab;

    private Vector3 _targetPosition;

    private void Update()
    {
        Vector3 moveDirection = (_targetPosition - transform.position).normalized;

        float distanceBeforeMoving = Vector3.Distance(_targetPosition, transform.position);

        float moveSpeed = 100f;
        transform.position += moveDirection * moveSpeed * Time.deltaTime;

        float distanceAfterMoving = Vector3.Distance(_targetPosition, transform.position);

        if(distanceBeforeMoving < distanceAfterMoving)
        {
            transform.position = _targetPosition;

            trailRenderer.transform.parent = null;

            Destroy(gameObject);

            Instantiate(bulletHitVFXPrefab, _targetPosition, Quaternion.identity);
        }
    }

    public void Setup(Vector3 targetPosition)
    {
        _targetPosition = targetPosition;
    }
}
