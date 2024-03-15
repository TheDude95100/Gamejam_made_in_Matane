using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class CompagnonDialogue : MonoBehaviour
{
    public Dialogue[] listeDialogue;
    public Dialogue[] listeReponse;
    public string nomPersonnage;

    public Dictionary<string, Dialogue> dictionnaireDialogue;

    public Dictionary<string, string> dictionnaireEvent;

    public Dictionary<string, Dialogue> dictionnaireReponse;

    private DialogueManager _dm;

    public TextMeshProUGUI textBouton;

    public bool flagEvent = false;
    public bool DialogueFini { get; set; }

    private void Start()
    {
        _dm = FindObjectOfType<DialogueManager>();
        textBouton.text = nomPersonnage;
        dictionnaireDialogue = new Dictionary<string, Dialogue>();
        dictionnaireReponse= new Dictionary<string, Dialogue>();
        dictionnaireEvent= new Dictionary<string, string>()
        {
           {"Mort", "Nom du mort"},
           // {"Loot", "Loot"}
            //{"Event", new Dialogue(introduction.nom, "Test")}
        };
        for (int indexDialogue = 0; indexDialogue < listeDialogue.Length; indexDialogue++)
        {
            dictionnaireDialogue.Add(listeDialogue[indexDialogue].nom, listeDialogue[indexDialogue]);
        }
        for (int indexDialogue = 0; indexDialogue < listeReponse.Length; indexDialogue++)
        {
            dictionnaireReponse.Add(listeReponse[indexDialogue].nom, listeReponse[indexDialogue]);
        }
    }

    public void TriggerDialogue(string dialogue)
    {
        flagEvent = false;
        if (dictionnaireEvent.Count > 0)
        {
            _dm.currentDialogue = dictionnaireEvent.First().Key;
            _dm.StartDialogue(new Dialogue(nomPersonnage, dictionnaireDialogue[dictionnaireEvent.First().Key].phrases));
            return;
        }
        if(DialogueFini) {_dm.StartDialogue(new Dialogue(nomPersonnage, dictionnaireDialogue["Dialogue Fin"].phrases)); return; }
        _dm.StartDialogue(new Dialogue(nomPersonnage,dictionnaireDialogue[dialogue].phrases));
        _dm.currentDialogue = dialogue;
    }   
}
