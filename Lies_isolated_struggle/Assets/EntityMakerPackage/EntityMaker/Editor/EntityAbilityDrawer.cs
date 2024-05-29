using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(EntityAbility))]
public class EntityAbilityDrawer : PropertyDrawer
{

    private SerializedProperty _name;
    private SerializedProperty _damage;
    private SerializedProperty _range;
    private SerializedProperty _element;

    //how to draw to the Inspector window
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);

        _name = property.FindPropertyRelative("_name");
        _damage = property.FindPropertyRelative("_damage");
        _range = property.FindPropertyRelative("_range");
        _element = property.FindPropertyRelative("_element");

        Rect foldOutBox = new Rect(position.xMin, position.yMin, position.size.x, EditorGUIUtility.singleLineHeight);
        property.isExpanded = EditorGUI.Foldout(foldOutBox, property.isExpanded, label);

        if(property.isExpanded)
        {
            DrawNameProperty(position);
            DrawDamageProperty(position);
            DrawRangeProperty(position);
            DrawElementProperty(position);
        }

        EditorGUI.EndProperty();
    }

    //request more vertical spacing
    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        int totalLines = 1;
        
        if(property.isExpanded)
        {
            totalLines += 3;
        }

        return EditorGUIUtility.singleLineHeight * totalLines;
    }

    private void DrawNameProperty(Rect position)
    {
        EditorGUIUtility.labelWidth = 70;
        float xPos = position.min.x;
        float yPos = position.min.y + EditorGUIUtility.singleLineHeight;
        float width = position.size.x * 0.4f;
        float height = EditorGUIUtility.singleLineHeight;

        Rect drawArea = new Rect(xPos, yPos, width, height);

        EditorGUI.PropertyField(drawArea, _name, new GUIContent("Name"));
    }

    private void DrawDamageProperty(Rect position)
    {
        Rect drawArea = new Rect(
                    position.min.x + (position.width * 0.5f), 
                    position.min.y + EditorGUIUtility.singleLineHeight, 
                    position.size.x * 0.5f, 
                    EditorGUIUtility.singleLineHeight
            );

        EditorGUI.PropertyField(drawArea, _damage, new GUIContent("Damage"));
    }

    private void DrawRangeProperty(Rect position)
    {
        Rect drawArea = new Rect(
                    position.min.x + (position.width * 0.5f),
                    position.min.y + 2 + EditorGUIUtility.singleLineHeight*2,
                    position.size.x * 0.5f,
                    EditorGUIUtility.singleLineHeight
            );

        EditorGUI.PropertyField(drawArea, _range, new GUIContent("Range"));
    }

    private void DrawElementProperty(Rect position)
    {
        EditorGUIUtility.labelWidth = 100;

        Rect drawArea = new Rect(
                    position.min.x + (position.width * 0.25f),
                    position.min.y + 4 + EditorGUIUtility.singleLineHeight*3,
                    position.size.x * 0.75f,
                    EditorGUIUtility.singleLineHeight
            );

        EditorGUI.PropertyField(drawArea, _element, new GUIContent("Element type"));
    }
}
