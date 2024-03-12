using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReponseButton : MonoBehaviour
{
    public CompagnonDialogue TalkingCharacter;

    private void OnEnable()
    {
        TalkingCharacter = FindObjectOfType<DialogueManager>().talkingCompagnon;
       
    }
    public void TriggerReponse(string dialogue)
    {
        FindObjectOfType<DialogueManager>().StartDialogue(TalkingCharacter.dictionnaireDialogue[dialogue]);
    }
}
