using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAIAction
{

    public GridPosition gridPosition;
    public int actionValue;

    public override string ToString()
    {
        return gridPosition.ToString() + " " + actionValue;
    }
}
