using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public Queue<string> phrases;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;

    public CompagnonDialogue talkingCompagnon;
    public string currentDialogue;
    public string chosenAnswer;
    public bool flag;
    public void StartDialogue(Dialogue dialogue)
    {
        flag = false;
        phrases = new Queue<string>();
        nameText.text = dialogue.nom;

        phrases.Clear();

        foreach(string phrase in dialogue.phrases)
        {
            phrases.Enqueue(phrase);
        }

        DisplayNextSentence();
    }


    public void DisplayNextSentence()
    {
       if(phrases.Count == 0)
        {
            EndDialogue();
            return;
        } 
       string phrase = phrases.Dequeue();
       StopAllCoroutines();
       StartCoroutine(TypeSentence(phrase));
    }
    IEnumerator TypeSentence(string phrase)
    {
        dialogueText.text = "";
        foreach (char lettre in phrase.ToCharArray())
        {
            dialogueText.text += lettre;
            yield return new WaitForSeconds(0.03f);
        }
    }
    public void EndDialogue()
    {
        flag = true;
    }

   public void SetCompagnonDialogue(CompagnonDialogue compagnon)
   {
        talkingCompagnon= compagnon;
   }

    public void ChangerAffinite()
    {
        
        int[] matriceReponse = talkingCompagnon.dictionnaireReponse[chosenAnswer].GetReactionAffinite();

        CompagnonDialogue[] listeCompagnon = FindObjectsOfType<CompagnonDialogue>();

        foreach (CompagnonDialogue compagnon in listeCompagnon)
        {
            int[] matriceCompagnon = compagnon.GetMatriceAffinite();
            int boostAffinite = 0;
            for (int indexMatriceAffinite =0; indexMatriceAffinite < matriceCompagnon.Length; indexMatriceAffinite++)
            {
                boostAffinite += matriceCompagnon[indexMatriceAffinite] * matriceReponse[indexMatriceAffinite];
            }
            compagnon.affinite += boostAffinite;
            Debug.Log(compagnon.nomPersonnage + " affinite: " + compagnon.affinite);
        }
    }
}
