using UnityEngine;

[CreateAssetMenu(fileName = "Destination", menuName = "Map/Destination", order = 1)]
public class Destination : ScriptableObject
{
    [SerializeField]
    private string _name = "...";
    [SerializeField]
    private Destination[] _listDestinationBefore ;
    [SerializeField]
    private Destination[] _listDestinationAfter;
    [SerializeField]
    private int _difficulty = 0;
    [SerializeField]
    private int _ressourceRate = 0;

    public string Name => _name;
    public Destination[] ListDestinationBefore => _listDestinationBefore;
    public Destination[] ListDestinationAfter => _listDestinationAfter;
    public int Difficulty => _difficulty;
    public int RessourceRate => _ressourceRate;

}
