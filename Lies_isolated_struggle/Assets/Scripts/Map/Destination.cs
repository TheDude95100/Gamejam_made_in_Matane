using UnityEngine;

[CreateAssetMenu(fileName = "Destination", menuName = "Map/Destination", order = 1)]
public class Destination : ScriptableObject
{
    [SerializeField] private string destinationName;

    [SerializeField] private Destination[] listDestinationBefore;
    [SerializeField] private Destination[] listDestinationAfter;

    [SerializeField] private int difficulty;
    [SerializeField] private int ressourceRate;

    public string GetDestinationName()
    {
        return destinationName;
    }

    public int GetDifficulty()
    {
        return difficulty;
    }

    public int GetRessourceRate()
    {
        return ressourceRate;
    }
}
