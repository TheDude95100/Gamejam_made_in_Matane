using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueBox : MonoBehaviour
{
    public Canvas canvas;

    private void Start()
    {
        if (canvas == null)
        {
            canvas = GetComponent<Canvas>();
        }
    }
    public Canvas GetCanvas() { return canvas; }
}
