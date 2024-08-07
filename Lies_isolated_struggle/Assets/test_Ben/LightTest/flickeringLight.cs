using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flickeringLight : MonoBehaviour
{
    [SerializeField] private Light _myLight;
    [SerializeField] private float _maxInterval = 1;
    [SerializeField] private float _maxFlicker = 0.2f;
    [SerializeField] private Color _lightColor;

    float _defaultIntensity;
    bool _isOn;
    float _timer;
    float _delay;
    Material _neonmaterial;

    private void Start()
    {
        _defaultIntensity = _myLight.intensity;
        _myLight.color = _lightColor;
        _neonmaterial = GetComponent<MeshRenderer>().material;
        _neonmaterial.SetColor("_EmissionColor", _lightColor * _defaultIntensity);
    }

    void Update()
    {
        _timer += Time.deltaTime;
        if (_timer > _delay)
        {
            ToggleLight();
        }
    }

    void ToggleLight()
    {
        _isOn = !_isOn;

        if (_isOn)
        {
            _myLight.intensity = _defaultIntensity;
            _delay = Random.Range(0, _maxInterval);
        }
        else
        {
            _myLight.intensity = Random.Range(0.6f, _defaultIntensity);
            _delay = Random.Range(0, _maxFlicker);
        }
        _neonmaterial.SetColor("_EmissionColor", _lightColor * _myLight.intensity);

        _timer = 0;
    }
}
