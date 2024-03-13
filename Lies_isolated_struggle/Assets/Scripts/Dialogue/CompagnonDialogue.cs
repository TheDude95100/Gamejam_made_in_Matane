using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class CompagnonDialogue : MonoBehaviour
{
    public Dialogue[] listeDialogue;

    public Dialogue introduction;


    public Dictionary<string, Dialogue> dictionnaireDialogue;

    public Dialogue dialogueFin;

    public Dictionary<string, string> dictionnaireEvent;

    private DialogueManager _dm;

    public bool flagEvent = false;
    public bool DialogueFini { get; set; }

    private void Start()
    {
        _dm = FindObjectOfType<DialogueManager>();
        dictionnaireDialogue = new Dictionary<string, Dialogue>();
        dialogueFin.nom = introduction.nom;
        dictionnaireDialogue.Add("Introduction", introduction);
        dictionnaireEvent= new Dictionary<string, string>()
        {
            {"Mort", "Nom du mort"},
            {"Loot", "Loot"}
            //{"Event", new Dialogue(introduction.nom, "Test")}
        };
        for (int indexDialogue = 0; indexDialogue < listeDialogue.Length; indexDialogue++)
        {
            dictionnaireDialogue.Add(listeDialogue[indexDialogue].nom, listeDialogue[indexDialogue]);
        }
        foreach(KeyValuePair<string,Dialogue> entry in dictionnaireDialogue)
        {
            Debug.Log(entry.Key);
        }
    }

    public void TriggerDialogue(string dialogue)
    {
        flagEvent = false;
        if (dictionnaireEvent.Count > 0)
        {
            _dm.currentDialogue = dictionnaireEvent.First().Key;
            _dm.StartDialogue(new Dialogue(introduction.nom, dictionnaireDialogue[dictionnaireEvent.First().Key].phrases));
            dictionnaireEvent.Remove(dictionnaireEvent.First().Key);
            return;
        }
        if(DialogueFini) {_dm.StartDialogue(dialogueFin); return; }
        _dm.StartDialogue(new Dialogue(introduction.nom,dictionnaireDialogue[dialogue].phrases));
        _dm.currentDialogue = dialogue;
    }   
}
