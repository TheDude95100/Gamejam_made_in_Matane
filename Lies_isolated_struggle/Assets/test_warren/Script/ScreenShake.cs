using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    private CinemachineImpulseSource _cinemachineImpulseSource;
    public static ScreenShake Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("There'S more than one ScreenShake! " + transform + " - " + Instance);
            Destroy(gameObject);
            return;
        }

        Instance = this;

        _cinemachineImpulseSource = GetComponent<CinemachineImpulseSource>();
    }

    public void Shake(float intensity = 1f)
    {
        _cinemachineImpulseSource.GenerateImpulse(intensity);
    }
}
