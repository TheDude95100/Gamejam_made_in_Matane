using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flickeringFire : MonoBehaviour
{
    [SerializeField] private Light myLight;
    [SerializeField] private float maxInterval = 1f;
    [SerializeField] private float maxDisplacement = 0.25f;
    [SerializeField] private Color _lightColor;

    float targetIntensity;
    float lastIntensity;
    float interval;
    float timer;
    
    Vector3 targetPosition;
    Vector3 lastPosition;
    Vector3 origin;

    Material fireMaterial;

    private void Start()
    {
        origin = transform.position;
        lastPosition = origin;
        myLight.color = _lightColor;
        fireMaterial = GetComponent<MeshRenderer>().material;
        fireMaterial.SetColor("_EmissionColor", _lightColor);
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer > interval)
        {
            lastIntensity = myLight.intensity;
            targetIntensity = Random.Range(0.5f, 1f);
            timer = 0;
            interval = Random.Range(0, maxInterval);

            targetPosition = origin + Random.insideUnitSphere * maxDisplacement;
            lastPosition = myLight.transform.position;
        }

        myLight.intensity = Mathf.Lerp(lastIntensity, targetIntensity, timer / interval);
        myLight.transform.position = Vector3.Lerp(lastPosition, targetPosition, timer / interval);
    }
}
