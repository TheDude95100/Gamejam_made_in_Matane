using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Outliner : MonoBehaviour
{

    [SerializeField] private SpriteRenderer _spriteRenderer;
    
    public void OnClick()
    {
        _spriteRenderer.color = Color.white;
    }
}
