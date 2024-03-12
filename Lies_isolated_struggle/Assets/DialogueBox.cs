using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DialogueBox : MonoBehaviour
{
    public Canvas canvas;

    public GameObject reponsePanel;
    public GameObject scriptText;
    public GameObject continueButton;

    private void Start()
    {
        if (canvas == null)
        {
            canvas = GetComponent<Canvas>();
        }
    }
    public Canvas GetCanvas() { return canvas; }

    public void SetActiveReponsePanel()
    {
        reponsePanel.SetActive(true);
    }

    public void SetActiveScriptText() { 
        scriptText.SetActive(true);
    }
    public void SetActiveContinueButton() { 
        continueButton.SetActive(true);
    }

    public void UnsetActiveContinueButton()
    {
        continueButton.SetActive(false);
    }
    public void UnsetActiveReponsePanel()
    {
        reponsePanel.SetActive(false);
    }

    public void UnsetActiveScriptText()
    {
        scriptText.SetActive(false);
    }

    public void ActivateCanvas()
    {
        canvas.enabled = true;
    }

    public void DeactivateCanvas()
    {
        canvas.enabled = false;
    }

    public void CheckDialogueStatus()
    {

        DialogueManager manager = FindObjectOfType<DialogueManager>();
        Debug.Log("Manager flag: " + manager.flag);
        Debug.Log("Dialogue flag: " + manager.talkingCompagnon.DialogueFini);
        if (manager.flag && !manager.talkingCompagnon.DialogueFini)
        {
            UnsetActiveContinueButton();
            UnsetActiveScriptText();
            SetActiveReponsePanel();
        }
        if(manager.flag && manager.talkingCompagnon.DialogueFini)
        {
            DeactivateCanvas();
        }
    }

    public void ResetCanvas()
    {
        UnsetActiveReponsePanel();
        SetActiveScriptText();
        SetActiveContinueButton();
    }
}
