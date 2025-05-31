using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TurnSystemUI : MonoBehaviour
{
    [SerializeField]
    private Button endTurnButton;
    [SerializeField]
    private TextMeshProUGUI turnNumberText;
    [SerializeField]
    private TextMeshProUGUI groupTurnText;

    private void Start()
    {
        endTurnButton.onClick.AddListener(() =>
        {
            TurnSystem.Instance.NextTurn();
        });

        TurnSystem.Instance.OnTurnChanged += TurnSystem_OnTurnChanged;

        UpdateTurnNumberText(); 
        UpdateGroupTurnText();
        UpdateEndTurnButtonVisibility();
    }

    private void UpdateTurnNumberText()
    {
        turnNumberText.text = "Turn " + TurnSystem.Instance.GetTurnNumber();
    }
    private void UpdateGroupTurnText()
    {
        if(TurnSystem.Instance.IsPlayerTurn())
        {
            groupTurnText.text = "Player Turn";
            groupTurnText.color = new Color(0.384701f, 0.5462776f, 0.8962264f, 1f);
        }
        else
        {
            groupTurnText.text = "Enemy Turn";
            groupTurnText.color = new Color(0.8490566f, 0.2923638f, 0.3787437f, 1f);
        }
    }
    private void UpdateEndTurnButtonVisibility()
    {
        endTurnButton.gameObject.SetActive(TurnSystem.Instance.IsPlayerTurn());
    }

    private void TurnSystem_OnTurnChanged(object sender, EventArgs e)
    {
        UpdateTurnNumberText();
        UpdateGroupTurnText();
        UpdateEndTurnButtonVisibility();
    }
}
