using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReponseButton : MonoBehaviour
{
    public CompagnonDialogue TalkingCharacter;

    private DialogueManager _dm;

    public int idButton;

    private void OnEnable()
    {
        _dm = FindObjectOfType<DialogueManager>();
        TalkingCharacter = _dm.talkingCompagnon;
        
       
    }
    public void TriggerReponse()
    {
        string dialogue = _dm.currentDialogue;
        if (dialogue != "Mort" && dialogue != "Event" && dialogue != "Loot" && dialogue != "Crit")
        {
            TalkingCharacter.DialogueFini = true;
        }
        _dm.chosenAnswer = dialogue + " " + idButton;
        _dm.StartDialogue(new Dialogue(TalkingCharacter.introduction.nom, TalkingCharacter.dictionnaireDialogue[_dm.currentDialogue + " " + idButton].phrases));
        _dm.talkingCompagnon.flagEvent= true;
    }
}
