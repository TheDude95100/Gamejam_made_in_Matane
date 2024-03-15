using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public class Reponse : Dialogue
{

    public int affiniteSurvie;
    public int affiniteCombat;
    public int affiniteAnimaux;


    private int[] _reactionAffinite;
    public Reponse(string nom, string texte) : base(nom, texte)
    {
        this.nom = nom;
        this.phrases[0] = texte;
        _reactionAffinite = new int[3];
        _reactionAffinite[0] = affiniteSurvie;
        _reactionAffinite[1] = affiniteCombat;
        _reactionAffinite[2] = affiniteAnimaux;
    }

    public int[] GetReactionAffinite()
    {
        _reactionAffinite = new int[3];
        _reactionAffinite[0] = affiniteSurvie;
        _reactionAffinite[1] = affiniteCombat;
        _reactionAffinite[2] = affiniteAnimaux;
        return _reactionAffinite;
    }
    
}
