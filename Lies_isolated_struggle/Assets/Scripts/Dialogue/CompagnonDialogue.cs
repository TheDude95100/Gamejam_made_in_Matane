using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CompagnonDialogue : MonoBehaviour
{
    public Dialogue[] listeDialogue;

    public Dialogue introduction;


    public Dictionary<string, Dialogue> dictionnaireDialogue;




    private void Start()
    {
        dictionnaireDialogue = new Dictionary<string, Dialogue>();
        dictionnaireDialogue.Add("introduction", introduction);
        Debug.Log(listeDialogue.Length);
        for (int indexDialogue = 0; indexDialogue < listeDialogue.Length; indexDialogue++)
        {
                listeDialogue[indexDialogue].nom = GetComponent<DialogueTrigger>().dialogue.nom;
                dictionnaireDialogue.Add("reponse" + (indexDialogue+1), listeDialogue[indexDialogue]);
        }
    }

    public void TriggerDialogue(string dialogue)
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dictionnaireDialogue[dialogue]);
    }
}
