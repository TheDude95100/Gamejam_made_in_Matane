using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompagnonDialogue : MonoBehaviour
{

    public Canvas canvas;
    public void ActivateCanvas()
    {
        canvas.enabled= true;
    }

    public void DeactivateCanvas()
    {
        canvas.enabled= false;
    }
}
