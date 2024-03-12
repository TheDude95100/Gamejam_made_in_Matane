using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CompagnonDialogue : MonoBehaviour
{
    public Dialogue[] listeDialogue;

    public Dialogue introduction;


    public Dictionary<string, Dialogue> dictionnaireDialogue;

    public Dialogue dialogueFin;

    public bool DialogueFini { get; set; }

    private void Start()
    {
        dictionnaireDialogue = new Dictionary<string, Dialogue>();
        dialogueFin.nom = introduction.nom;
        dictionnaireDialogue.Add("introduction", introduction);
        Debug.Log(listeDialogue.Length);
        for (int indexDialogue = 0; indexDialogue < listeDialogue.Length; indexDialogue++)
        {
                listeDialogue[indexDialogue].nom = introduction.nom;
                dictionnaireDialogue.Add("reponse" + (indexDialogue+1), listeDialogue[indexDialogue]);
        }
    }

    public void TriggerDialogue(string dialogue)
    {
        if(DialogueFini) { FindObjectOfType<DialogueManager>().StartDialogue(dialogueFin); return; }
        FindObjectOfType<DialogueManager>().StartDialogue(dictionnaireDialogue[dialogue]);
    }
}
