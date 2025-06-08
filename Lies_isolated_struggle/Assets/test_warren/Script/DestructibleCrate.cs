using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleCrate : MonoBehaviour
{
    private GridPosition _gridPosition;
    public static event EventHandler OnAnyDestroyed;

    private void Start()
    {
        _gridPosition = LevelGrid.Instance.GetGridPosition(transform.position);
    }

    public GridPosition GetGridPosition()
    {
        return _gridPosition;
    }

    public void TakeDamage()
    {
        Destroy(gameObject);
        OnAnyDestroyed?.Invoke(this, EventArgs.Empty);
    }
}
