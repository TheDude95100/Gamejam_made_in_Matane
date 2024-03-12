using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsButton : MonoBehaviour
{
    [SerializeField] GameObject settingUI;
    [SerializeField] GameObject pauseUI;
    public void Setting()
    {
        pauseUI.SetActive(false);
        settingUI.SetActive(true);
    }
}