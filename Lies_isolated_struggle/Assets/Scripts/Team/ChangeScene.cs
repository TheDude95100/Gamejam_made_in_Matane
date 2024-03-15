using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;

public class ChangeScene : MonoBehaviour
{
    // Start is called before the first frame update
    public void GetSene2()
    {
        GameManager.Scene2();
    }

    public void GetSene1()
    {
        GameManager.Scene1();
    }
}
