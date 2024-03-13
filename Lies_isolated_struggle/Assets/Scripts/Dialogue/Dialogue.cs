using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    public string nom;

    [TextArea(3,10)]
    public string[] phrases;

    public Dialogue(string nom,string[] phrases)
    {
        this.nom = nom;
        this.phrases = phrases;
    }
    public Dialogue(string nom, string texte)
    {
        this.nom = nom;
        string[] test = new string[1];
        test[0] = texte;
        this.phrases = test;
    }
}
