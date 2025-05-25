using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinAction : BaseAction
{

    private float rotationAmountDone;

    private void Update()
    {
        if (!isActive)
        {
            return;
        }

        float spinAmount = 360f * Time.deltaTime;
        transform.eulerAngles += new Vector3(0, spinAmount, 0);
        rotationAmountDone += spinAmount;

        if(rotationAmountDone >= 360)
        {
            isActive = false;
        }
    }

    public void Spin()
    {
        isActive = true;
        rotationAmountDone = 0;
        Debug.Log("Spin");
    }
}
