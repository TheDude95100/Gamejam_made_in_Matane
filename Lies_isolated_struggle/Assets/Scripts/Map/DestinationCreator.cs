using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DestinationCreator : MonoBehaviour
{


    [SerializeField] private GameObject destinationPrefab;
    [SerializeField] private GameObject destinationPrefabPlace;

    [SerializeField] private Destination[] listDestination;

    public void Start()
    {
        if (listDestination != null)
        {
            foreach(Destination destination in listDestination)
            {
                GameObject newDestination = Instantiate(destinationPrefab, destinationPrefabPlace.transform);
                newDestination.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = destination.Name;
                newDestination.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = destination.Difficulty.ToString();
                newDestination.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = destination.RessourceRate.ToString();
                newDestination.transform.GetChild(3).GetComponent<Button>().onClick.AddListener(transform.GetComponent<DestinationController>().ClickDestination);
            }
        }
    }
}
