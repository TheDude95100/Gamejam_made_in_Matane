using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    private Vector3 _targetPosition;

    private void Start()
    {
        _targetPosition = transform.position;
    }

    private void Update()
    {
        float stoppingDistance = .1f;
        if(Vector3.Distance(_targetPosition, transform.position) > stoppingDistance)
        {
            Vector3 moveDirection = (_targetPosition - transform.position).normalized;
            float moveSpeed = 4f;
            transform.position += moveDirection * moveSpeed * Time.deltaTime;
        }

        if(Input.GetKeyDown(KeyCode.D))
        {
            Move(new Vector3(-3,1,2));
        }
    }
    private void Move(Vector3 targetPosition)
    {
        _targetPosition = targetPosition;
    }
}
