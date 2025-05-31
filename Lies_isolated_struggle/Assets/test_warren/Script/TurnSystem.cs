using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnSystem : MonoBehaviour
{
    private int _turnNumber;
    private bool _isPlayerTurn;


    public event EventHandler OnTurnChanged;

    public static TurnSystem Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("There'S more than one TurnSystem! " + transform + " - " + Instance);
            Destroy(gameObject);
            return;
        }

        Instance = this;
        _turnNumber = 1;
        _isPlayerTurn = true;
    }

    public void NextTurn()
    {
        if(!_isPlayerTurn)
        {
            _turnNumber++;
        }

        _isPlayerTurn = !_isPlayerTurn;

        OnTurnChanged?.Invoke(this, EventArgs.Empty);
    }

    public int GetTurnNumber()
    {
        return _turnNumber;
    }

    public bool IsPlayerTurn()
    {
        return _isPlayerTurn;
    }
}
