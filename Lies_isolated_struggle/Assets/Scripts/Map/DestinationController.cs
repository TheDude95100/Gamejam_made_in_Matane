using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DestinationController : MonoBehaviour
{
    [SerializeField] private GameObject destinationPanel;
    private string destinationName;
    private string destinationDifficulty;
    private string destinationLootRate;

    private Transform parentButton;

    public void ClickDestination()
    {
        EventSystem currentEvent = EventSystem.current;
        GameObject selectedBtn = currentEvent.currentSelectedGameObject;

        parentButton = selectedBtn.transform.parent.transform;

        destinationName = parentButton.GetChild(0).GetComponent<TextMeshProUGUI>().text;
        destinationDifficulty = parentButton.GetChild(1).GetComponent<TextMeshProUGUI>().text;
        destinationLootRate = parentButton.GetChild(2).GetComponent<TextMeshProUGUI>().text;
        
        destinationPanel.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = destinationName;
        destinationPanel.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = "Difficulty : "+destinationDifficulty+"/10";
        destinationPanel.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = "Loot rate : "+destinationLootRate+"%";

        destinationPanel.SetActive(true);
    }

    public void ExitDestination()
    {
        destinationPanel.SetActive(false);
    }

    public void GoDestination()
    {
        //GameManager.Scene_Fight(destinationName);     //Quand on aura different niveau
        GameManager.Scene_Fight("Main_Fight");
    }
}
