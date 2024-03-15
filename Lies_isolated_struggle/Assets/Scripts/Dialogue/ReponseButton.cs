using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class ReponseButton : MonoBehaviour
{
    public CompagnonDialogue TalkingCharacter;

    private DialogueManager _dm;

    public int idButton;

    public TextMeshProUGUI textMeshPro;

    private void OnEnable()
    {
        _dm = FindObjectOfType<DialogueManager>();
        TalkingCharacter = _dm.talkingCompagnon;
        string dialogue = _dm.currentDialogue;
        textMeshPro.text = TalkingCharacter.dictionnaireReponse[dialogue + " " + idButton].phrases[0];
    }
    public void TriggerReponse()
    {
        string dialogue = _dm.currentDialogue;
        if (dialogue != "Mort" && dialogue != "Event" && dialogue != "Loot" && dialogue != "Crit")
        {
            TalkingCharacter.DialogueFini = true;
        }
        _dm.chosenAnswer = dialogue + " " + idButton;
        _dm.StartDialogue(new Dialogue(TalkingCharacter.nomPersonnage, TalkingCharacter.dictionnaireDialogue[_dm.currentDialogue + " " + idButton].phrases));
        if(_dm.talkingCompagnon.dictionnaireEvent.Count >0) { _dm.talkingCompagnon.dictionnaireEvent.Remove(_dm.talkingCompagnon.dictionnaireEvent.First().Key); }
        _dm.talkingCompagnon.flagEvent= true;
    }
}
