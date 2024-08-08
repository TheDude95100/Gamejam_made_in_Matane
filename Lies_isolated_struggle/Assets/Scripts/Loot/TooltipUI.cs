using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class TooltipUI : MonoBehaviour
{
    [SerializeField] private RectTransform _canvasRectTransform;
    [SerializeField] private RectTransform _background;
    [SerializeField] private TextMeshProUGUI _textMeshPro;
    [SerializeField] private float padding;
    [SerializeField] private Vector3 paddingFromCursor;

    private RectTransform _rectTransform;

    private void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
        gameObject.SetActive(false);
    }

    public void SetText(string itemName, string toolTipText)
    {
        _textMeshPro.SetText("<color=#FF0000>"+ itemName+ "</color>\n" + toolTipText);
        _textMeshPro.ForceMeshUpdate();

        Vector2 textSize = _textMeshPro.GetRenderedValues();
        Vector2 paddingSize = new Vector2(padding, padding);
        _background.sizeDelta = textSize+paddingSize;
    }
    
    private void Update()
    {
        _rectTransform.anchoredPosition = (Input.mousePosition+ paddingFromCursor) * _canvasRectTransform.localScale.x;
    }
}
