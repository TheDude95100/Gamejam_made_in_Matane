using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMode : MonoBehaviour
{
    [SerializeField] private int modeInt;
    [SerializeField] private PlayerController playerController;

    public void ChangeMode()
    {
        playerController.ChangeMode(modeInt);
    }
}
