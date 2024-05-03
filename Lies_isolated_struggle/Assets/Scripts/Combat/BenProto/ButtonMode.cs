using Combat.BenProto;
using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMode : MonoBehaviour
{
    [SerializeField] private int modeInt;

    public void ChangeMode()
    {
        CombatManager.instance.playerController.ChangeMode(modeInt);
    }
}
