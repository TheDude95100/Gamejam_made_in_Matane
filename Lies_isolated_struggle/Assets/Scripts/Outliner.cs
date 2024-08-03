using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Outliner : MonoBehaviour
{
    private Material _outerlineMaterial;

    private float _outerLineIsActive;

    private void Start()
    {
        _outerlineMaterial = GetComponent<Image>().material;
    }

    public void HoverOuterLine()
    {
        _outerLineIsActive = _outerlineMaterial.GetFloat("_ActiveOuterline");
        _outerlineMaterial.SetFloat("_ActiveOuterline", _outerLineIsActive==0f ? 1f : 0f);
    }


}
