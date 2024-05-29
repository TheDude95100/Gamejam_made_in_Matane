using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(SeparatorAttribute))]
public class SeperatorDrawer : DecoratorDrawer
{
    public override void OnGUI(Rect position)
    {
        SeparatorAttribute seperatorAttribute = attribute as SeparatorAttribute;

        Rect separatorRect = new Rect(
                position.xMin, 
                position.yMin + seperatorAttribute.Spacing, 
                position.width, 
                seperatorAttribute.Height
        );

        EditorGUI.DrawRect(separatorRect, Color.white);
    }

    public override float GetHeight()
    {
        SeparatorAttribute seperatorAttribute = attribute as SeparatorAttribute;

        float totalSpacing = seperatorAttribute.Spacing + 
                             seperatorAttribute.Height + 
                             seperatorAttribute.Spacing;

        return totalSpacing;
    }
}
