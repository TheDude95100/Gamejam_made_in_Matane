using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Outliner : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Material _outerlineMaterial;

    private float _outerLineIsActive;

    private void Start()
    {
        _outerlineMaterial = GetComponent<Image>().material;
        _outerLineIsActive = _outerlineMaterial.GetFloat("_ActiveOuterline");
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _outerlineMaterial.SetFloat("_ActiveOuterline", 1f);
        Debug.Log("Entrez");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _outerlineMaterial.SetFloat("_ActiveOuterline", 0f);
        Debug.Log("Sortie");
    }


}
